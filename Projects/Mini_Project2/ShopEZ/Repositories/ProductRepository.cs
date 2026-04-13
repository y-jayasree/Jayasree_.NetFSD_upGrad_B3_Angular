using ShopEZ.Data;
using ShopEZ.Models;
using ShopEZ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ShopEZ.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
            => _context = context;
        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products
                .AsNoTracking()
                .ToListAsync();
        public async Task<Product?> GetByIdAsync(int id) =>
            await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);
        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateAsync(int id, Product updated)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return null;

            product.Name = updated.Name;
            product.Description = updated.Description;
            product.Price = updated.Price;
            product.ImageUrl = updated.ImageUrl;
            product.Stock = updated.Stock;

            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ExistsAsync(int id) =>
            await _context.Products.AnyAsync(p => p.ProductId == id);
    }
}
