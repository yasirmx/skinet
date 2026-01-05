using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : Entity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria is not null)
            {
                query = query.Where(spec.Criteria);
            }

            return query;
        }
    }
}
