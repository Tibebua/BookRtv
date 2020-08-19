using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Data.Specification
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            //TEntity eg. book... thus IQueryable<Book> 
            // Criteria -> eg. Where(book.AuthorId == id)
            // Specification evaluator just adds the "where" and "Include" SQLqueries to 
            // the input query(_context.Books).. i.e. _context.Books.Where(b => b.Id ==id).Include(b => b.Author)
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
