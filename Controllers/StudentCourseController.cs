using Microsoft.AspNetCore.Mvc;
using saurav.Contratcs.Request;
using saurav.Contratcs.Response;
using saurav.Data;
using saurav.Entities;
using saurav.Repository.Interface;
using saurav.Service.Interface;

namespace saurav.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentCourseController : ControllerBase
{
    private readonly EfCoreDbcontext _context;
    private readonly IStudentCourseRepository _studentCourseRepository;
    private readonly IStudentCourseService _studentCourseService;

    public StudentCourseController(EfCoreDbcontext context, IStudentCourseRepository studentCourseRepository,
        IStudentCourseService studentCourseService)
    {
        _context = context;
        _studentCourseRepository = studentCourseRepository;
        _studentCourseService = studentCourseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var studentCourses = await _studentCourseRepository.GetAllAsync();

            return Ok(new { message = "Retrieved student courses", data = studentCourses });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var studentCourse = await _studentCourseRepository.GetByIdAsync(id);

            return Ok(new { message = "Retrieved student course", data = studentCourse });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> post([FromBody] StudentCourseRequestDto dto)
    {
        try
        {
            var studedntCourse = await _studentCourseService.AddAsync(dto);

            return Ok(studedntCourse);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] StudentCourseRequestDto dto)
    {
        try
        {
            var studentCourse = await _studentCourseService.UpdateAsync(id, dto);
            return Ok(studentCourse);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _studentCourseService.DeleteStudentCourse(id);
            return Ok();

        }
        catch (Exception e)
        {
          return BadRequest(e.Message);
        }
    }
}