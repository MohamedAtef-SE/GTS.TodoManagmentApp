using GTS.TodoApp.Core.Domain.Contracts.Specifications;

namespace GTS.TodoApp.Core.Domain.Contracts
{
    public interface IGenericRepository<TEntity,Tkey> where TEntity  : class where Tkey : IEquatable<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsyc(ISpecifications<TEntity,Tkey>? specs);
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task<bool> AddAsync(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
    }
}
