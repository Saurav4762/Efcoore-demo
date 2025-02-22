using Microsoft.EntityFrameworkCore;
using saurav.Data;
using saurav.Entities;
using saurav.Service.Interface;

namespace saurav.Service;

public class CourseServices : ICourseServices
{
    private readonly EfCoreDbcontext _context;

    public CourseServices(EfCoreDbcontext context)
    {
        _context = context;
    }


    public async Task<Course> AddCourseAsync(CourseRequestDto dto)
    {
        bool courseExists = await _context.Courses.AnyAsync(c => c.CourseName == dto.CourseName);

        if (courseExists)
        {
            throw new Exception($"Course {dto.CourseName} already exists");
        }

        var course = new Course()
        {
            CourseDescription = dto.CourseDescription,
            CourseName = dto.CourseName,
        };

        //Add Course to Database 
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return course;
    }

    public async Task<Course> UpdateCourseAsync(int id, CourseRequestDto input)
    {
      
        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            throw new Exception("Course not found");
        }
            
        course.CourseDescription = input.CourseDescription;
        course.CourseName = input.CourseName;
            
        _context.Update(course);
            
        await _context.SaveChangesAsync();
        
        return course;
    }

    public async Task DeleteCourseAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
            
        if (course == null)
        {
            throw new Exception("Course not found");
        }
            
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

    }
}