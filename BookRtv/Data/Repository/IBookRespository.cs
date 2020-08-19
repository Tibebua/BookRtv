using BookRtv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Data.Repository
{
    public interface IBookRespository
    {
        Task<Book> GetBookAsync(int id);
        Task<IReadOnlyList<Book>> GetBooksAsync();
        Task<IReadOnlyList<Book>> GetBooksByAuthor(int id);
        Task<IReadOnlyList<Author>> GetAuthorsAsync();
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}
