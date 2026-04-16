using System.ComponentModel.DataAnnotations;

namespace WebApplication13.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required,MinLength(3)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,Phone]
        public string Phone { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
