using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public int? CourseId { get; set; }

        [ValidateNever]
        public Course Course { get; set; }
    }

}
