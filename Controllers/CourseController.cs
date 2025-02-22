using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saurav.Data;
using saurav.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saurav.Contratcs.Response;
using saurav.Service.Interface;

namespace saurav.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase 
{
    private readonly EfCoreDbcontext _context;
    private readonly ICourseServices _courseService;

    public CourseController(EfCoreDbcontext context, ICourseServices courseService)
    {
        _context = context;
        _courseService = courseService ;
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
    public async Task<IActionResult> GetAllCourses()
    {
        try
        {
            var courses = await _context.Courses.Select(x=> new CourseRresponseDto()
            {
                CourseDescription = x.CourseDescription,
                CourseName = x.CourseName,
            }).ToListAsync();
            return Ok(courses);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
     
    //Get  : api/course/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(int id)
    {
        try
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                throw new Exception("Course not found");
            }

            return Ok(course);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    //PUT : api/course/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, CourseRresponseDto check)
    {
        try
        {
            var course = await _context.Courses.FindAsync(id);
            
            return Ok(course);

        }
       
        catch (Exception ex)
        {
            return BadRequest("Something went wrong");
        }
    }
    
    //DELETE : api/course/{id0}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        try
        {
            await _context.Courses.FindAsync(id);
            
            return Ok("Course deleted");

        }
        catch (Exception e)
        {
            return BadRequest("Something went wrong");
        }
    }
}