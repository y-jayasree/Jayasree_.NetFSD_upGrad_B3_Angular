using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required,MinLength(3)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
