using ShopEZ.DTOs.Product;
using ShopEZ.Models;
using ShopEZ.Repositories.Interfaces;
using ShopEZ.Services.Interfaces;

namespace ShopEZ.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(MapToDTO);
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product is null ? null : MapToDTO(product);
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO dto)
        {
            var existing = await _repo.GetAllAsync();

            if (existing.Any(p => p.Name.ToLower() == dto.Name.ToLower()))
                throw new InvalidOperationException("Product already exists.");

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock
            };

            var created = await _repo.CreateAsync(product);
            return MapToDTO(created);
        }

        public async Task<ProductDTO?> UpdateProductAsync(int id, CreateProductDTO dto)
        {
            var updated = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock
            };

            var result = await _repo.UpdateAsync(id, updated);
            return result is null ? null : MapToDTO(result);
        }

        public async Task<bool> DeleteProductAsync(int id) =>
            await _repo.DeleteAsync(id);

        private static ProductDTO MapToDTO(Product p) => new()
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
            Stock = p.Stock
        };
    }
}
