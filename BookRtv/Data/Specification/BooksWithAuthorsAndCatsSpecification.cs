using BookRtv.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookRtv.Data.Specification
{
    public class BooksWithAuthorsAndCatsSpecification : Specification<Book>
    {
        //this just adds id, and include statements too the specification class
        // btw // -> means "or else",  && means "also"
        public BooksWithAuthorsAndCatsSpecification(string sort, int? authorId, 
            int? catId)
            : base(b => 
                //(string.IsNullOrEmpty(search.Search) || 
                //b.BookName.ToLower().Contains(search.Search)) &&
                (!authorId.HasValue || b.AuthorId == authorId) &&
                (!catId.HasValue || b.CategoryId == catId)
            )
        {
            AddIncludeStatements(b => b.Author);
            AddIncludeStatements(b => b.Category);
            AddOrderByExp(b => b.BookName);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "author":
                        AddOrderByExp(b => b.Author.AuthorName);
                        break;
                    case "category":
                        AddOrderByExp(b => b.Category.CategoryName);
                        break;
                    default:
                        AddOrderByExp(b => b.BookName);
                        break;
                }
            }
        }

        public BooksWithAuthorsAndCatsSpecification(int id) : base(b => b.Id == id)
        {
            AddIncludeStatements(b => b.Author);
            AddIncludeStatements(b => b.Category);
        }
    }
}
