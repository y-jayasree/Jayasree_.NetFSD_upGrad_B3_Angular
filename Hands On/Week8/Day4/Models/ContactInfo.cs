using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required, StringLength(50, MinimumLength = 2)] 
        public string FirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression(@"^[6-9]\d{9}$")]
        public long MobileNo { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
