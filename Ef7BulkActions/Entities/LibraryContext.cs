using Microsoft.EntityFrameworkCore;

namespace Ef7BulkActions.Entities
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            :base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
