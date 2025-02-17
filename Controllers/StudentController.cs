using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using saurav.Data;
using saurav.Entities;

namespace saurav.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly EfCoreDbcontext _dbcontext;

    public  StudentController (EfCoreDbcontext dbcontext)
    {
        _dbcontext = dbcontext;
        
    }

    

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _dbcontext.Students.ToListAsync();
        return Ok  (students);
    }
    
}