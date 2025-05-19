using GTS.TodoApp.Core.Domain.Contracts;
using GTS.TodoApp.Core.Domain.Contracts.Specifications;
using Microsoft.EntityFrameworkCore;

namespace GTS.TodoApp.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class where TKey : IEquatable<TKey>
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsyc(ISpecifications<TEntity,TKey>? specs)
        {
            var query = SpecificationBuilder<TEntity,TKey>.GetQuery(_dbContext.Set<TEntity>(),specs);
            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            var result = await _dbContext.AddAsync(entity);

            return result.State is EntityState.Added;
        }
        public bool Update(TEntity entity)
        {
            var result = _dbContext.Update(entity);
            return result.State is EntityState.Modified;
        }

        public bool Delete(TEntity entity)
        {
            var result = _dbContext.Set<TEntity>().Remove(entity);
            return result.State is EntityState.Deleted;
        }
    }
}
