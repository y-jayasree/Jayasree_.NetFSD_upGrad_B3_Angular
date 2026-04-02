using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ContactInfo
    {
            [Key]
            public int ContactId { get; set; }

            [Required(ErrorMessage = "First Name is required")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is required")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Company Name is required")]
            public string CompanyName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Enter valid email")]
            public string EmailId { get; set; }

            [Required(ErrorMessage = "Mobile number is required")]
            [RegularExpression(@"^[0-9]{10}$")]
            public long MobileNo { get; set; }

            [Required(ErrorMessage = "Designation is required")]
            public string Designation { get; set; }
        }
}
