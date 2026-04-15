using System.ComponentModel.DataAnnotations;

namespace WebApplication6.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        [RegularExpression("Admin|User")]
        public string Role { get; set; }
    }
}
