using saurav.Contratcs.Response;
using saurav.Entities;

namespace saurav.Repository.Interface;

public interface IStudentRepository
{
    Task<StudentResponseDto> GetStudentById (int id );
    Task<List<StudentResponseDto>> GetStudent (int id);
    
}