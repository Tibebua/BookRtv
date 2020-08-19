using BookRtv.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Data.Repository
{
    public class BookRepository : IBookRespository
    {
        private readonly BookRtvContext _context;

        public BookRepository(BookRtvContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _context.Books
                .Where(b => b.Id == id)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Book>> GetBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

        [HttpGet("booksbyauthor{id}")]
        public async Task<IReadOnlyList<Book>> GetBooksByAuthor(int id)
        {
            return await _context.Books
                .Where(b => b.AuthorId == id)
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
