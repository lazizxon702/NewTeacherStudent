using StudentTeacher.Student;

namespace WebApplication3.model;

public class Departments
{
    public int Id { get; set; }
    public string? Name  { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
 
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    public IEnumerable<Student>? Students { get; set; }
}