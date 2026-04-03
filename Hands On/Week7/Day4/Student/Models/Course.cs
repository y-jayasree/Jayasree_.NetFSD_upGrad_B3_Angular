using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Course
    {
        [Required]
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
        
        //one to many
        public List<Student> Students { get; set; } 
    }
}
