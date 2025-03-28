using Microsoft.EntityFrameworkCore;
using db_controller.Models;
namespace db_controller
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibrarySystem;Trusted_Connection=True;");
        }
    }
}
