using Microsoft.EntityFrameworkCore;
using saurav.Contratcs.Response;
using saurav.Data;
using saurav.Entities;
using saurav.Repository.Interface;
using saurav.Service.Interface;

namespace saurav.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly EfCoreDbcontext _context;

    public CourseRepository(EfCoreDbcontext context)
    {
        _context = context;
    }


    public async Task<CourseResponseDto> GetCourseById(int id, CourseResponseDto dto)
    {
        var course = await _context.Courses
            .Where(c => c.Id == id)
            .Select(c => new CourseResponseDto()
            {
                CourseId = c.Id,
                CourseName = c.CourseName,
                CourseDescription = c.CourseDescription,
            }).FirstOrDefaultAsync();


        if (course == null)
        {
            throw new Exception("Course not found");
        }

        return course;
    }

    public async Task<List<CourseResponseDto>> GetCourse(CourseResponseDto output)
    {
        var courses = await _context.Courses
            .Select(x => new CourseResponseDto()
                 {
                     CourseDescription = x.CourseDescription,
                     CourseName = x.CourseName,
                 }).ToListAsync();

        return courses;
    }
}