using System.ComponentModel.DataAnnotations;

namespace WebApplication9.DTOs
{
    public class ContactDto
    {
        [Required,MinLength(3)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
