using Microsoft.EntityFrameworkCore;
using Contact01.Models;

namespace Contact01.Models // Ensure this matches your project structure
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        // Optional: If you have categories
        public DbSet<Category> Categories { get; set; }

        // Optional: Override OnModelCreating if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships or seed data if necessary
        }
    }
}
