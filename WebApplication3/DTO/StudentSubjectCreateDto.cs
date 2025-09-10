namespace WebApplication3.Dto;

public class StudentSubjectCreateDto
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public int Mark { get; set; }
}