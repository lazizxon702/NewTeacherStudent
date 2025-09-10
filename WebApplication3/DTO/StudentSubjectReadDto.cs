using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Dto;

[Table("StudentSubjectReadDto")]
public class StudentSubjecReadDto
{


    public int StudentId { get; set; }
    public string? StudentFullName { get; set; }

    public int SubjectId { get; set; }
    public string? SubjectName { get; set; }

    public int Mark { get; set; }

    public DateTime CreatedDate { get; set; }
}