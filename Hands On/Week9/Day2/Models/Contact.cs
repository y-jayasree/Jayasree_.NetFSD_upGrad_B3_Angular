using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required,MinLength(3)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
    }
}
