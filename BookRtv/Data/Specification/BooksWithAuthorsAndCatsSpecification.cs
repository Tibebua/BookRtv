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
        public BooksWithAuthorsAndCatsSpecification()
        {
            AddIncludeStatements(b => b.Author);
            AddIncludeStatements(b => b.Category);
        }

        public BooksWithAuthorsAndCatsSpecification(int id) : base(b => b.Id == id)
        {
            AddIncludeStatements(b => b.Author);
            AddIncludeStatements(b => b.Category);
        }
    }
}
