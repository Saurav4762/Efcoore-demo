using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saurav.Data;
using saurav.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saurav.Contratcs.Response;
using saurav.Repository.Interface;
using saurav.Service.Interface;

namespace saurav.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase 
{
    private readonly EfCoreDbcontext _context;
    private readonly ICourseServices _courseService;
    private readonly ICourseRepository _courseRepository;

    public CourseController(EfCoreDbcontext context, ICourseServices courseService, ICourseRepository courseRepository)
    {
        _context = context;
        _courseService = courseService ;
        _courseRepository = courseRepository;
    }
    
    //POST
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseRequestDto input)
    {
        try
        { 
            var course = await _courseService.AddCourseAsync(input);
                
            return CreatedAtAction("GetCourse", new { id = course.Id }, course);

        }
        catch (Exception e)
        {
            return BadRequest("Add course failed");
        }
    }
    
    //GET
    [HttpGet]
    public async Task<IActionResult> GetAllCourses(CourseResponseDto output)
    {
        try
        {
            var course = await _courseRepository.GetCourse(output);
            return Ok(course);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
     
    //Get  : api/course/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(int id,CourseResponseDto output)
    {
        try
        {
            var course = await _courseRepository.GetCourseById(id, output);

            return Ok(course);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    //PUT : api/course/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourseAsync(int id, CourseRequestDto input)
    {
        try
        {
            var course = await _courseService.UpdateCourseAsync(id,input);
            
            return Ok(course);

        }
       
        catch (Exception ex)
        {
            return BadRequest("Something went wrong");
        }
    }
    
    //DELETE : api/course/{id0}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourseAsync(int id)
    {
        try
        {
            await _courseService.DeleteCourseAsync(id);
            
            return Ok("Course deleted");

        }
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
    }
}