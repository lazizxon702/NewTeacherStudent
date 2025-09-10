using WebApplication3.model;

namespace StudentTeacher.Student;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
    public string? Gender { get; set; }
    public int GradeLevel  { get; set; }
    public int DepartmentId { get; set; }
    public Departments Departments { get; set; }
    public DateTime CreatedDate {get; set;}  = DateTime.UtcNow;
    public List<StudentsSubjects> StudentsSubjects { get; set; }
                                                                                                                        
}