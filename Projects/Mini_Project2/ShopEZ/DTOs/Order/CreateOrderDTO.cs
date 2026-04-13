using System.ComponentModel.DataAnnotations;

namespace ShopEZ.DTOs.Order
{
    public class CreateOrderDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Cart cannot be empty")]
        public List<CartItemDTO> CartItems { get; set; } = new();
    }
}
