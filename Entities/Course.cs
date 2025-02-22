using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace saurav.Entities;

public class Course
{
   
   
    public int Id { get; set; }
    
    public string CourseName { get; set; }
    public string CourseDescription { get; set; }
    
 
    public List<Student> Students { get; set; } = new List<Student>();
    
}