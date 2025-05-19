using GTS.TodoApp.Core.Domain.Contracts.Specifications;
using System.Linq.Expressions;

namespace GTS.TodoApp.Core.Application.Specifications
{
    public abstract class BaseSpecification<TEntity,TKey> : ISpecifications<TEntity, TKey> where TEntity : class where  TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }

        public Expression<Func<TEntity, object>>? OrderBy { get; set; }

        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; }

        public BaseSpecification(Expression<Func<TEntity, bool>>? criteria = null)
        {
            Criteria = criteria;
        }

        public abstract void SortedBy(string? sort);
       
    }
}
