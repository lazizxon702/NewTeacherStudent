using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Dto;
using WebApplication3.Interface;
using WebApplication3.model;

namespace WebApplication1.Services;
    
public class StudentSubjectService(AppDbContext db) : IStudentSubjectService
 {
    
     /// <summary>
    ///  Read
    /// </summary>
    
     public async Task<StudentSubjecReadDto> GetAllStudentSubject()
    {
        var result = await db.StudentsSubjects
            .Include(x => x.Student)
            .Include(x => x.Subject)
            .Select( x => new StudentSubjecReadDto
            {
                StudentId = x.StudentId,
                StudentFullName = x.Student.Name,
                SubjectId = x.SubjectId,
                SubjectName = x.Subject.Name,
                Mark = x.Mark,
                CreatedDate = x.CreatedDate
            })
            .FirstOrDefaultAsync();
        
        return result;
    }
    
     /// <summary>
    ///  Create 
    /// </summary>
    
    public async Task<string> PostStudentSubject(StudentSubjectCreateDto dto)
    {
        var exists = await db.StudentsSubjects
            .AnyAsync(x => x.StudentId == dto.StudentId && x.SubjectId == dto.SubjectId);
        
        if (exists)
        {
            return "This student is already assigned to this subject.";
        }
        
        
        var studentSubject = new StudentsSubjects
        {
            StudentId = dto.StudentId,
            SubjectId = dto.SubjectId,
            Mark = dto.Mark
        };
        
        db.StudentsSubjects.Add(studentSubject);
        await db.SaveChangesAsync();
 
         return "Successfully created.";
    }
 }