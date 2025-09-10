using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Dto;
using WebApplication3.Interface;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentSubjectsController(AppDbContext context, IStudentSubjectService servis) : ControllerBase
{
    
    private readonly IStudentSubjectService _StudentSubjectService = servis;
    public AppDbContext Context { get; set; } = context;

    /// GET All Students
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _StudentSubjectService.GetAllStudentSubject();
        return Ok(result);
    } 
                
    /// POST the Students
         [HttpPost]
         public async Task<IActionResult> Create([FromBody] StudentSubjectCreateDto dto)
         {
             if (!ModelState.IsValid)
                 return BadRequest(ModelState);
     
             var result = await _StudentSubjectService.PostStudentSubject(dto);


             return Ok(result);
         }
 }