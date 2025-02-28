using Microsoft.EntityFrameworkCore;
using saurav.Contratcs.Response;
using saurav.Data;
using saurav.Repository.Interface;

namespace saurav.Repository;

public class StudentCourseRepository : IStudentCourseRepository
{
    private readonly EfCoreDbcontext _context;

    public StudentCourseRepository(EfCoreDbcontext context)
    {
        _context = context;
    }

    public async Task<List<StudentCourseResponseDto>> GetAllAsync()
    {
        var studentCourses = await _context.StudentCourses
            .Select(x => new StudentCourseResponseDto
            {
                Id = x.Id,
                CourseId = x.CourseId,
                StudentId = x.StudentId,
                StudentName = x.Student.FirstName + " " + x.Student.LastName,
                CourseName = x.Course.CourseName


            }).ToListAsync();

        return studentCourses;
    }

    public Task<StudentCourseResponseDto> GetByIdAsync(int id)
    {
        var studentCourse = _context.StudentCourses
            .Where(x => x.Id == id)
            .Select(x=> new StudentCourseResponseDto
            {
                Id = x.Id,
                CourseId = x.CourseId,
                StudentId = x.StudentId,
                StudentName = x.Student.FirstName + " " + x.Student.LastName,
                CourseName = x.Course.CourseName,
            }).FirstOrDefaultAsync();
        
        return studentCourse;
    }
}