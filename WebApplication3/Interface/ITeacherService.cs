using WebApplication3.DTO;

namespace WebApplication3.Interface;

public interface  ITeacherService
{
    public Task<TeacherReadDto> GetById(int id);
    public Task<TeacherReadDto> GetAll();
    public Task<string> PostTeacher(TeacherCreateDto dto);

    public Task<bool> UpdateTeacher(int id ,TeacherUpdateDto dto);
    
    public Task<bool> DeleteTeacher(int id);
    

}