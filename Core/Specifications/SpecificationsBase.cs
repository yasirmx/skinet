using Core.Interfaces;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class SpecificationsBase<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
    {
        protected SpecificationsBase() : this(null) { }

        public Expression<Func<T, bool>>? Criteria => criteria;

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        public bool IsDistinct { get; private set; }

        public int Take { get; private set; }

        public int Skip  { get; private set; }

        public IQueryable<T> ApplyCriteria(IQueryable<T> queryable)
        {
            if (Criteria is not null)
            {
                queryable = queryable.Where(Criteria);
            }
            return queryable;
        }

        public bool IsPagingEnabled => true;

        protected void AddOrderBy(Expression<Func<T, object>>? orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>>? orderByExpression)
        {
            OrderByDescending = orderByExpression;
        }

        protected void ApplyDistinct()
        {
            IsDistinct = true;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
    }

    public class SpecificationsBase<T, TResult>(Expression<Func<T, bool>>? criteria) : SpecificationsBase<T>(criteria), ISpecification<T, TResult>
    {
        protected SpecificationsBase() : this(null) { }

        public Expression<Func<T, TResult>>? Select { get; private set; }

        protected void AddSelect(Expression<Func<T, TResult>>? selectExpression)
        {
            Select = selectExpression;
        }

    }
}
