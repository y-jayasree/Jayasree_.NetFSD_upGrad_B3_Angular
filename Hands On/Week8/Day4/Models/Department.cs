using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required, StringLength(100),MinLength(3)]
        public string DepartmentName { get; set; }

        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
