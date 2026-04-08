using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        public long MobileNo { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
