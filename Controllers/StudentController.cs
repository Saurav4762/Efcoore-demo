using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saurav.Data;
using saurav.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saurav.Contratcs.Request;
using saurav.Contratcs.Response;
using saurav.Repository.Interface;
using saurav.Service;
using saurav.Service.Interface;

namespace saurav.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly EfCoreDbcontext _dbcontext;
    
    private readonly IStudentServices _studentService;
    
    private readonly IStudentRepository _studentRepository;

    public StudentController(EfCoreDbcontext dbcontext, IStudentServices studentService, IStudentRepository studentRepository)
    {
        _dbcontext = dbcontext;
        _studentService = studentService;
        _studentRepository = studentRepository;
    }


    //GET: api/student
    [HttpGet]
    public async Task<IActionResult> GetStudents(int id )
    {
        try
        {
            var students = await _studentRepository.GetStudent(id);
            return Ok(students);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //GEt: api/student/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        try
        {
          var student = await _studentRepository.GetStudentById(id);

            return Ok(student);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //POST : api/student
    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent([FromBody] StudentRequestDto input)
    {
        try
        {
            var student = await _studentService.AddStudentAsync(input);

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    //PUT : api/atudent/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, StudentRequestDto input)
    {
        try
        {
            var student = await _studentService.UpdateStudentAsync(id, input);
            
            return Ok("Student updated");
        }

        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        try
        {
            await _studentService.DeleteStudentAsync(id);

            return Ok("Student deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}