using GTS.TodoApp.Core.Domain.Contracts.Specifications;

namespace GTS.TodoApp.Infrastructure.Persistence
{
    public static class SpecificationBuilder<TEntity,TKey> where TEntity : class where TKey : IEquatable<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecifications<TEntity, TKey>? specs)
        {
            if(specs is null) return query;

            if (specs.Criteria is not null)
            {
                query = query.Where(specs.Criteria);
            }

            if (specs.OrderBy is not null)
            {
                query = query.OrderBy(specs.OrderBy);
            }
            else if (specs.OrderByDesc is not null)
            {
                query = query.OrderByDescending(specs.OrderByDesc);
                return query;
            }

            return query;
        }
    }
}
