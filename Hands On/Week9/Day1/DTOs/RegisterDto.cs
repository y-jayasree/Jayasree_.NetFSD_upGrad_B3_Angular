using System.ComponentModel.DataAnnotations;

namespace WebApplication9.DTOs
{
    public class RegisterDto
    {
        [Required, EmailAddress]
        public string EmailId { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
