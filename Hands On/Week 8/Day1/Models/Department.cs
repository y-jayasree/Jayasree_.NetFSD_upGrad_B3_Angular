using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
