namespace WebApplication3.model;

public class Subject
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int GradeLevel { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public IEnumerable<TeacherSubject>? TeacherSubjects { get; set; } 
    public IEnumerable<StudentsSubjects>? StudentsSubjects { get; set; } 


}