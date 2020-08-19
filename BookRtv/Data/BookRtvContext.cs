using BookRtv.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Data
{
    public class BookRtvContext: DbContext
    {
        public BookRtvContext(DbContextOptions<BookRtvContext> options): base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
