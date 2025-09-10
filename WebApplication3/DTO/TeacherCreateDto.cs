using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO;

public class TeacherCreateDto
{
    public string Name {get; set; }
    public int CityId { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string Gender { get; set; }
    public int SubjectId { get; set; }
    public int DepartmentId { get; set; }
    
}