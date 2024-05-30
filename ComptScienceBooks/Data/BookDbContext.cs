using ComptScienceBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace ComptScienceBooks.Data
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext>options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
