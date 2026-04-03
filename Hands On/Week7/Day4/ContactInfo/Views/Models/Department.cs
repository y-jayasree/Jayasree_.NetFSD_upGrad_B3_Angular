using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Navigation Property
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
