using Microsoft.EntityFrameworkCore;
using WebApplication15.Models;

namespace WebApplication15.Data
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
