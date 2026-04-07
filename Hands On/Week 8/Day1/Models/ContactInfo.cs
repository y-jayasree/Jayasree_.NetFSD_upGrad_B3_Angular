using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [StringLength(100)]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        public long MobileNo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Max 50 characters")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Please select a Company")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Please select a Department")]
        public int DepartmentId { get; set; }

        // For display only — no validation needed
        public string? CompanyName { get; set; }
        public string? DepartmentName { get; set; }
    }
}
