using saurav.Entities;

namespace saurav.Service.Interface;

public interface ICourseServices
{
    Task<Course> AddCourseAsync(CourseRequestDto dto);
    Task<Course> UpdateCourseAsync(int id, CourseRequestDto input);
    Task DeleteCourseAsync(int id);
}