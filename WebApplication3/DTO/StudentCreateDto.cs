namespace WebApplication3.DTO;

public class StudentCreateDto
{
    public string Name { get; set; }
    public int GradeLevel { get; }
    public int CityId { get; set; }
    public int DepartmentId { get; set; }
    public string? Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}