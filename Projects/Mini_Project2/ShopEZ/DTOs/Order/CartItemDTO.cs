using System.ComponentModel.DataAnnotations;

namespace ShopEZ.DTOs.Order
{
    public class CartItemDTO
    {
        [Required] public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
