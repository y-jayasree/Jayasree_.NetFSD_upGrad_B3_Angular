using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication4.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }
        public string Designation { get; set; }

        // Foreign Keys
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        // Navigation Properties
        public Company? Company { get; set; }
        public Department? Department { get; set; }
    }

}
