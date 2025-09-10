
namespace WebApplication3.DTO;

public class StudentReadDto
{
    public string Name { get; set; }
    public int GradeLevel { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set;}
    public string? CityName { get; set; }
    public string? DepartmentName { get; set; }
}