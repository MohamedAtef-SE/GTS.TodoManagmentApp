using GTS.TodoApp.Core.Domain.Contracts;
using GTS.TodoApp.Core.Domain.Contracts.UnitOfWork;
using GTS.TodoApp.Infrastructure.Persistence;
using GTS.TodoApp.Infrastructure.Persistence.Repositories;
using System.Collections.Concurrent;

namespace GTS.TodoApp.Core.Application.UnitOfWork
{
    public class UnitOfWork(AppDbContext _dbContext) : IUnitOfWork
    {
        public ConcurrentDictionary<string, object> _repositories { get; set; } = new();

        
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>()
            where TEntity : class 
            where Tkey : IEquatable<Tkey>
        {
            return (IGenericRepository<TEntity, Tkey>)_repositories.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, Tkey>(_dbContext));
        }
       
        public async Task<bool> CompleteAsync() => await _dbContext.SaveChangesAsync() > 0;

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    }
}
