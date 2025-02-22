using Microsoft.EntityFrameworkCore;
using saurav.Contratcs.Request;
using saurav.Data;
using saurav.Entities;
using saurav.Service.Interface;

namespace saurav.Service;

public class StudentService : IStudentServices
{
    private readonly EfCoreDbcontext _dbcontext;

    public StudentService(EfCoreDbcontext context)
    {
        _dbcontext = context;
    }
    
    public async Task<Student> AddStudentAsync(StudentRequestDto input )
    {
        var courseExists = await _dbcontext.Courses.AnyAsync(c => c.Id == input.CourseId);
        // Validate CourseId
        if (!courseExists)
        {
            throw new Exception("Course doesn't exist");
        }

        var student = new Student()
        {
            CourseId = input.CourseId,
            Address = input.Address,
            Phone = input.Phone,
            FirstName = input.FirstName,
            LastName = input.LastName,
            Email = input.Email,
        };


        // Add Student to Database
        _dbcontext.Students.Add(student);
        await _dbcontext.SaveChangesAsync();
        
        return student;
    }

    public async Task<Student> UpdateStudentAsync(int id, StudentRequestDto input)
    {
        var student = await _dbcontext.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception("Student doesn't exist");
        }

        student.Address = input.Address;
        student.Phone = input.Phone;
        student.FirstName = input.FirstName;
        student.LastName = input.LastName;
        student.Email = input.Email;

        _dbcontext.Update(student);


        await _dbcontext.SaveChangesAsync();
        return student;
    }

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _dbcontext.Students.FindAsync(id);

        if (student == null)
        {
            throw new Exception("Student doesn't exist");
        }

        _dbcontext.Students.Remove(student);
        await _dbcontext.SaveChangesAsync();
    }
}
