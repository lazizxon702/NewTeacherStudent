using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO;

public class TeacherReadDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string CityName { get; set; }
    public DateTime DateOfBirth { get; set;}
    [Required]
    public string Gender { get; set;}
    public int SubjectId { get; set; }
    public int DepartmentId { get; set; }
    
}