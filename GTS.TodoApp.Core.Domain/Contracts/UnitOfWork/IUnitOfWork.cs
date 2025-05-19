namespace GTS.TodoApp.Core.Domain.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity,Tkey> GetRepository<TEntity,Tkey>() where TEntity : class where Tkey : IEquatable<Tkey>;
        Task<bool> CompleteAsync();
    }
}
