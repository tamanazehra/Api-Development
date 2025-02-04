using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
        public class BooksDbContext: DbContext
        {
            public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
            {
            }
            public DbSet<Books> Books { get; set; }
        }

}

