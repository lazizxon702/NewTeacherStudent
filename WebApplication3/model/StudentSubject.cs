using StudentTeacher.Student;                                                                                           
                                                                                                                        
namespace WebApplication3.model;                                                                                        
                                                                                                                        
public class StudentsSubjects                                                                                           
{                                                                                                                       
        public int Id { get; set; }                                                                                     
        public int StudentId { get; set; }                                                                              
        public Student? Student { get; set; }                                                                           
        public int SubjectId { get; set; }                                                                              
        public int Mark { get; set; }                                                                                   
        public bool IsDeleted { get; set; }                                                                             
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;                                                    
        public Subject? Subject { get; set; }                                                                           
                                                                                                                        
}                                                                                                                       
                                                                                                                        