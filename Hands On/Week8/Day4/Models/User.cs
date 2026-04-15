using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(4)]
        public string Username { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required]
        [RegularExpression("Admin|User")]
        public string Role { get; set; }
    }
}
