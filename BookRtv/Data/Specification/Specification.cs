using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookRtv.Data.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification()
        {
        }

        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new
            List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByExp { get; private set; }

        public Expression<Func<T, object>> OrderByDescendingExp { get; private set; }

        protected void AddIncludeStatements(Expression<Func<T, object>> includeExp)
        {
            Includes.Add(includeExp);
        }
        protected void AddOrderByExp(Expression<Func<T, object>> orderByExpression)
        {
            OrderByExp = orderByExpression;
        }
        protected void AddOrderByDescendingExp(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescendingExp = orderByDescExpression;
        }

    }
}
