using Microsoft.EntityFrameworkCore;
using StudentTeacher.Student;
using WebApplication3.Data;
using WebApplication3.DTO;
using WebApplication3.Interface;

namespace WebApplication3.Services;

public class StudentService(AppDbContext db) : IStudentService
{
    public async Task<StudentReadDto> servis(int id)
    {
        var student = await db.Students
            .Include(s => s.City)
            .Include(s => s.Departments)
            .Where(s => s.Id == id)
            .Select(s => new StudentReadDto
            {
                Name = s.Name,
                Gender = s.Gender,
                DateOfBirth = s.DateOfBirth,
                GradeLevel = s.GradeLevel,
                CityName = s.City.Name,
                DepartmentName = s.Departments.Name
            })
            .FirstOrDefaultAsync();

        return student;
    }

    public async Task<string> PostStudent(StudentCreateDto dto)
    {
        if (await db.Cities.AnyAsync(c => c.Id != dto.CityId))
            return "City topilmadi";

        if (await db.Departments.AnyAsync(d => d.Id != dto.DepartmentId))
            return "Department topilmadi";

        var student = new Student
        {
            Name = dto.Name,
            Gender = dto.Gender,
            DateOfBirth = dto.DateOfBirth,
            GradeLevel = dto.GradeLevel,
            CityId = dto.CityId,
            DepartmentId = dto.DepartmentId
        };

        await db.Students.AddAsync(student);
        await db.SaveChangesAsync();

        return "Student muvaffaqiyatli qo‘shildi";
    }

    public async Task<List<StudentReadDto>> GetAllStudents()
    {
        var students = await db.Students
            .Include(s => s.City)
            .Include(s => s.Departments)
            .Select(s => new StudentReadDto
            {
                Name = s.Name,
                Gender = s.Gender,
                DateOfBirth = s.DateOfBirth,
                GradeLevel = s.GradeLevel,
                CityName = s.City.Name,
                DepartmentName = s.Departments.Name
            })
            .ToListAsync();

        return students;
    }

    public async Task<bool> StudentUpdate(int id, StudentUpdateDto dto)
    {
        var student = await db.Students.FindAsync(id);
        if (student == null) return false;

        student.Name = dto.Name;
        student.Gender = dto.Gender;
        student.DateOfBirth = dto.DateOfBirth;
        student.GradeLevel = dto.GradeLevel;
        student.CityId = dto.CityId;
        student.DepartmentId = dto.DepartmentId;

        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> StudentDelete(int id)
    {
        var student = await db.Students.FindAsync(id);
        if (student == null) return false;

        db.Students.Remove(student);
        await db.SaveChangesAsync();
        return true;
        
    }
    
}