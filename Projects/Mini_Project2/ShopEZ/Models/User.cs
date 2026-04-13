using System.ComponentModel.DataAnnotations;

namespace ShopEZ.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer";       

        // Navigation
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}