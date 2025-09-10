using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.DTO;
using WebApplication3.Interface;
        
namespace WebApplication3.Controller;
        
        
    [ApiController]
    [Route("[controller]")]
    public class StudentController(IStudentService studentService, AppDbContext db) : ControllerBase
    {   
        public AppDbContext Context = db;
        
        /// GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentService.GetAllStudents();
            return Ok(students);
        }
        
        /// GET BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var dto = await studentService.servis(id);
             if (dto == null) return NotFound();
             
            return Ok(dto);
        }
        
        /// Create
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        
            var createdStudent = await studentService.PostStudent(dto);
            return Ok(createdStudent);
        }
           
        /// UPDATE
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentUpdateDto dto)
        {
            var updated = await studentService.StudentUpdate(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        /// DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await studentService.StudentDelete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

  