using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO;

public class StudentUpdateDto
{
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Gender { get; set; } 
    public DateTime DateOfBirth { get; set; }
    public int GradeLevel { get; set; }
    public int CityId { get; set; }
    public int DepartmentId { get; set; }
}