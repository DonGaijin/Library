using Microsoft.EntityFrameworkCore;

namespace testAPI1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

    }
}
