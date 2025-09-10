namespace WebApplication3.model;

public class TeacherSubject
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
    
    public DateTime CreatedDate {get; set;} = DateTime.UtcNow;
    public DateTime? LastUpdatedDate {get; set;} = DateTime.UtcNow;
    public bool IsDeleted {get; set;}
    
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
    
}
