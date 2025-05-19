using System.Linq.Expressions;

namespace GTS.TodoApp.Core.Domain.Contracts.Specifications
{
    public interface ISpecifications<TEntity,TKey> where TEntity : class where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity,bool>>? Criteria {  get; }
        public Expression<Func<TEntity,object>>? OrderBy { get; set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; }

        public void SortedBy(string sort);
    }
}
