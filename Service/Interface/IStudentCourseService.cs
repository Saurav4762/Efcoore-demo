using saurav.Contratcs.Request;
using saurav.Contratcs.Response;
using saurav.Entities;

namespace saurav.Service.Interface;

public interface IStudentCourseService
{
    Task<StudentCourse> AddAsync(StudentCourseRequestDto dto);
    Task<StudentCourse> UpdateAsync(int id,StudentCourseRequestDto dto);
    Task DeleteStudentCourse(int id );
}