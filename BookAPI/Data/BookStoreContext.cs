using BookAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 
namespace BookAPI.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Books> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseNpgsql("Host=localhost;Database=Forge2;Port=5432;User ID=postgres;Password=minhduc;Pooling=true;");
            optionsBuilder.UseNpgsql("Host=localhost;Database=Forge2;Port=5432;User ID=postgres;Password=minhduc;Pooling=true;");
        }
    }
}