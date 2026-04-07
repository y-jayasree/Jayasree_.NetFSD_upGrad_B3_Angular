using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string CourseName { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
