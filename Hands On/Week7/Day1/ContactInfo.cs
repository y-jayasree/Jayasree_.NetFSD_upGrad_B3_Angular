using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage ="Id is required")]
        public int ContactId { get; set; }
        [Required (ErrorMessage ="enter firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="enter lastname")]
        public string LastName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid email with @")]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter valid 10-digits number")]
        public string MobileNo { get; set; }
        [Required]
        public string Designation { get; set; }
    }
}
