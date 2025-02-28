using Microsoft.EntityFrameworkCore;
using saurav.Contratcs.Request;
using saurav.Data;
using saurav.Entities;
using saurav.Service.Interface;

namespace saurav.Service;

public class StudentCourseService : IStudentCourseService
{
    private readonly EfCoreDbcontext _context;

    public StudentCourseService(EfCoreDbcontext context)
    {
        _context = context;
    }

    public async Task<StudentCourse> AddAsync(StudentCourseRequestDto dto)
    {
        var exists = await _context.StudentCourses
            .AnyAsync(x => x.CourseId == dto.CourseId && x.StudentId == dto.StudentId);

        if (exists)
        {
            throw new Exception("Student is already enrolled in this course");

        }

        var studentExists = await _context.Students
            .AnyAsync(x => x.Id == dto.StudentId);
        if (!studentExists)
        {
            throw new Exception("Student not found");
        }

        var courseExists = await _context.Courses
            .AnyAsync(x => x.Id == dto.CourseId);
        if (!courseExists)
        {
            throw new Exception("Course not found");
        }

        var studentcourse = new StudentCourse
        {
            CourseId = dto.CourseId,
            StudentId = dto.StudentId,
        };
        _context.StudentCourses.Add(studentcourse);
        await _context.SaveChangesAsync();

        return studentcourse;
    }

    public async Task<StudentCourse> UpdateAsync(int id, StudentCourseRequestDto dto)
    {
        var studentCourse = await _context.StudentCourses.FindAsync(id);
        if (studentCourse == null)
        {
            throw new Exception("StudentCourse not found");
        }

        var studentExists = await _context.Students
            .AnyAsync(sc => sc.Id == dto.StudentId);
        if (!studentExists)
        {
            throw new Exception("Student not found");
        }

        var courseExists = await _context.Courses
            .AnyAsync(sc => sc.Id == dto.CourseId);
        if (!courseExists)
        {
            throw new Exception("Course not found");
        }

        var exists =
            await _context.StudentCourses.AnyAsync(sc => sc.CourseId == dto.CourseId && sc.StudentId == dto.StudentId);
        if (!exists)
        {
            throw new Exception("StudentCourse not found");
        }

        studentCourse.CourseId = dto.CourseId;
        studentCourse.StudentId = dto.StudentId;

        await _context.SaveChangesAsync();
        return studentCourse;


    }

    public async Task DeleteStudentCourse(int id)
    {
        var studentCourse = await _context.StudentCourses.FindAsync(id);
        if (studentCourse == null)
        {
            throw new Exception("StudentCourse not found");
        }

        _context.StudentCourses.Remove(studentCourse);
        await _context.SaveChangesAsync();
    }
}

   