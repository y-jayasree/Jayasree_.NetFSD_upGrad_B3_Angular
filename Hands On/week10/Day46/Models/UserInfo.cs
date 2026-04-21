using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class UserInfo
    {
        [Key]
        public string EmailId { get; set; }

        [Required,MinLength(6)]
        public string Password { get; set; }

        [Required,MinLength(3)]
        public string Role { get; set; }
    }
}
