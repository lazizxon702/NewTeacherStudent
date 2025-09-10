using StudentTeacher.Student;

namespace WebApplication3.model;

public class Teacher
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
    public string? Gender { get; set; }
    public int SubjectId { get; set; }  
    public Subject Subject { get; set;  }
    public int DepartmentId { get; set; }
    public DateTime CreatedDate {get; set;} = DateTime.UtcNow;
    public DateTime LastUpdatedDate  { get; set; } = DateTime.UtcNow;
    public Student? Student { get; set; }
    public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }