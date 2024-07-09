using BookService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.DataContext
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }

    }
}
