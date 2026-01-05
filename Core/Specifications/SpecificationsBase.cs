using Core.Interfaces;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class SpecificationsBase<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
    {
        protected SpecificationsBase() : this(null) { }

        public Expression<Func<T, bool>>? Criteria => criteria;
    }
}
