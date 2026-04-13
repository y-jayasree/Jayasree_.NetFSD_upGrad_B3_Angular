using System.ComponentModel.DataAnnotations;

namespace ShopEZ.DTOs.Product
{
    public class CreateProductDTO
    {
        [Required][MaxLength(200)] public string Name { get; set; } = string.Empty;
        [MaxLength(1000)] public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        [Required][Range(0, int.MaxValue)] public int Stock { get; set; }
    }
}
