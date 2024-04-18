using Biblioteka.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BorrowHistory> BorrowHistorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sci-fi", Description = "Space jurney" },
                new Category { Id = 2, Name = "Horror", Description = "Scary movie" });

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Witcher", Description = "Wiedźmin", Author = "Sapkowski", isAvailable = true, CategoryId = 1},
                new Book { Id = 2, Title = "Witcher 2", Description = "Wiedźmin 2", Author = "Sapkowski", isAvailable = true, CategoryId = 2 });
        }

    }
}
