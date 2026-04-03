using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Company 
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            //data for dropdowns
            modelBuilder.Entity<Company>().HasData(
            new Company { CompanyId = 1, CompanyName = "Solutions" },
            new Company { CompanyId = 2, CompanyName = "ABC" },
            new Company { CompanyId = 3, CompanyName = "Designs" },
            new Company { CompanyId = 4, CompanyName = "Coders" },
            new Company { CompanyId = 5, CompanyName = "XYZ" },
            new Company { CompanyId = 6, CompanyName = "abc" }
             );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "HR" },
                new Department { DepartmentId = 2, DepartmentName = "IT" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" },
                new Department { DepartmentId = 4, DepartmentName = "Sales" }
            );

        }


    }
}
