using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }

        // foreign key
        public int CourseId { get; set; }
        [ValidateNever]
        public Course Course { get; set; }  // navigation property
    }
}

