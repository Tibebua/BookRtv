using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookRtv.Data.Specification
{
    public interface ISpecification<T>
    {
        // Expression type is just lambda expression
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderByExp { get; }
        Expression<Func<T, object>> OrderByDescendingExp { get; }
    }
}
