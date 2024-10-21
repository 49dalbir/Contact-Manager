using Microsoft.EntityFrameworkCore;

namespace Contact01.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Data for Category
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Friends" },
                new Category { CategoryId = 2, CategoryName = "Family" },
                new Category { CategoryId = 3, CategoryName = "Work" }
            );
        }
    }
}
