using WebApplication3.Dto;

namespace WebApplication3.Interface;

public interface IStudentSubjectService
 {
    public Task<StudentSubjecReadDto> GetAllStudentSubject();
    public Task<string> PostStudentSubject(StudentSubjectCreateDto dto);
    
 }