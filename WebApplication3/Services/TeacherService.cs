using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.DTO;
using WebApplication3.Interface;
using WebApplication3.model;

namespace WebApplication3.Services;

public class TeacherService(AppDbContext db) : ITeacherService
{
    public async Task<TeacherReadDto> GetById(int id)
    {
        var teacher = await db.Teachers
            .Include(t => t.City)
            .Include(t => t.Subject)
            .Where(t => t.Id == id)
            .Select(t => new TeacherReadDto
            {
                Name = t.Name,
                Gender = t.Gender,
                DateOfBirth = t.DateOfBirth,
                CityName = t.City.Name,
                SubjectId = t.SubjectId
            })
            .FirstOrDefaultAsync();
        return teacher;
    }

    public async Task<TeacherReadDto> GetAll()
    {
        var teachers = await db.Teachers
            .Include(t => t.City)
            .Include(t => t.TeacherSubjects)
            .ThenInclude(ts => ts.Subject)
            .Select(t => new TeacherReadDto
            {
                Id = t.Id,
                Name = t.Name,
                CityName = t.City.Name,
                DateOfBirth = t.DateOfBirth,
                Gender = t.Gender,
                DepartmentId = t.DepartmentId
            }).ToListAsync();
        return teachers.FirstOrDefault();
    }

    public async Task<string> PostTeacher(TeacherCreateDto dto)
    {
        if (!await db.Cities.AnyAsync(c => c.Id == dto.CityId))
            return "City Topilmadi!";
        if (!await db.Departments.AnyAsync(c => c.Id == dto.DepartmentId))
            return "Department Topilmadi!";
        if (!await db.Subjects.AnyAsync(c => c.Id == dto.SubjectId))
            return "Subject Topilmadi!";

        var teacher = new Teacher
        {
            Name = dto.Name,
            CityId = dto.CityId,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            SubjectId = dto.SubjectId,
            DepartmentId = dto.DepartmentId
        };

        await db.Teachers.AddAsync(teacher);
            await db.SaveChangesAsync();
            return "dto";

    }

    public async Task<bool> UpdateTeacher(int id ,TeacherUpdateDto dto)
    {
        var teacher = await db.Teachers.FindAsync(id);
        if (teacher == null) return false;
        
        teacher.Name = dto.Name;
        teacher.CityId = dto.CityId;
        teacher.DateOfBirth = dto.DateOfBirth;
        teacher.Gender = dto.Gender;
        teacher.SubjectId = dto.SubjectId;
        teacher.DepartmentId = dto.DepartmentId;
        teacher.LastUpdatedDate = DateTime.UtcNow;
        await db.SaveChangesAsync();
        return true;

    }

    public async Task<bool> DeleteTeacher(int id)
    {
        var teacher = await db.Teachers.FindAsync(id);
        if (teacher == null) return false;
        db.Teachers.Remove(teacher);
        await db.SaveChangesAsync();
        return true;
    }
}

