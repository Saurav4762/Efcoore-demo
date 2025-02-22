using saurav.Contratcs.Request;
using saurav.Entities;

namespace saurav.Service.Interface;

public interface IStudentServices
{
    Task<Student> AddStudentAsync(StudentRequestDto dto);
    Task<Student> UpdateStudentAsync (int id, StudentRequestDto input);
    Task DeleteStudentAsync(int id);

}