using WebApplication3.DTO;

namespace WebApplication3.Interface;

public interface IStudentService
 {
    Task<StudentReadDto> servis(int id);
    Task<string> PostStudent(StudentCreateDto dto);
    Task<List<StudentReadDto>> GetAllStudents();
    Task<bool> StudentUpdate(int id, StudentUpdateDto dto);
    Task<bool> StudentDelete(int id);
 }