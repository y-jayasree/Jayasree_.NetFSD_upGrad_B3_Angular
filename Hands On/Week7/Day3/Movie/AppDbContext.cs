using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "A",
                    Genre = "Action",
                    ReleaseDate = new DateTime(2022, 3, 25),
                    Price = 250,
                    Rating = "5"
                },
                new Movie
                {
                    Id = 2,
                    Title = "B",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(2015, 7, 10),
                    Price = 200,
                    Rating = "4.5"
                }
            );
        }
    }
}
