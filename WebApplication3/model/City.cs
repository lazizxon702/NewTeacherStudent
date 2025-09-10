using StudentTeacher.Student;

namespace WebApplication3.model;

public class City
{ 
   
    public int Id { get; set; }
  
    public string? Name { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}