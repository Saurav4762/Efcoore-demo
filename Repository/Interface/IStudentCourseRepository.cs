using saurav.Contratcs.Response;
using saurav.Entities;

namespace saurav.Repository.Interface;

public interface IStudentCourseRepository
{
    Task<List<StudentCourseResponseDto>> GetAllAsync();
    Task<StudentCourseResponseDto> GetByIdAsync(int id);
    
}