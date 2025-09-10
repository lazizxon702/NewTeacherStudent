using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;

namespace WebApplication3.Controller;

[ApiController]
[Route("api/[controller]")]

public class TopController : ControllerBase
{
    private readonly AppDbContext _context;

    public TopController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("top10-students")]
    public IActionResult GetTop10Students()
    {
        var topStudent = _context.StudentsSubjects
            .OrderByDescending(ss => ss.Mark)
            .Take(10)
            .Select(ss => new
            {
             StudentName = ss.Student.Name,
             SubjectName = ss.Subject.Name,
             Mark = ss.Mark
            })
            .ToList();
        return Ok(topStudent);
    }
}