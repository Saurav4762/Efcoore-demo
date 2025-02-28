using Microsoft.EntityFrameworkCore;
using saurav.Contratcs.Response;
using saurav.Data;
using saurav.Entities;
using saurav.Repository.Interface;

namespace saurav.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly EfCoreDbcontext _dbcontext;

    public StudentRepository(EfCoreDbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }


    public async Task<StudentResponseDto> GetStudentById(int id )
    {
        var students = await _dbcontext.Students
            .Where(x => x.Id == id)
            .Select(x=> new StudentResponseDto
            {
                StudentId = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                Address = x.Address,
                CourseId = x.CourseId,
            }).FirstOrDefaultAsync();
        
        return students;

    }

    
    public Task<List<StudentResponseDto>> GetStudent(int id)
    {
        var student = _dbcontext.Students.Select(x=> new StudentResponseDto
        {
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Phone = x.Phone,
            Address = x.Address,
            CourseId = x.CourseId,
        }).ToListAsync();
        
        return student;
    }
}