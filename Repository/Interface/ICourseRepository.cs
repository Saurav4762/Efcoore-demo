using saurav.Contratcs.Response;
using saurav.Entities;

namespace saurav.Repository.Interface;

public interface ICourseRepository 
{
    Task<CourseResponseDto> GetCourseById (int id, CourseResponseDto output);
    Task<List<CourseResponseDto>> GetCourse (CourseResponseDto output);
    
}