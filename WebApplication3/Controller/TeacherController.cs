using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.DTO;
using WebApplication3.Interface;

namespace WebApplication3.Controller;

[ApiController]
[Route("[controller]")]
public class TeacherController(AppDbContext db, ITeacherService teacherService) : ControllerBase
{
    private readonly AppDbContext _context = db;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await teacherService.GetAll();
        return Ok(teachers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dto = await teacherService.GetById(id);
        return Ok(dto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TeacherCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await teacherService.PostTeacher(dto);

        if (result == null)
            return NotFound("City, Department yoki Subject topilmadi.\n Id lar soni City = 12 , Department = 6 , Subject = 6");

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherUpdateDto dto)
    {
        var updated = await teacherService.UpdateTeacher(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var deleted = await teacherService.DeleteTeacher(id);
        if (!deleted) return NotFound();
        return NoContent();
    } 
}