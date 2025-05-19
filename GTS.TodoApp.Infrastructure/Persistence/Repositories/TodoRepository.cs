using GTS.TodoApp.Core.Domain.Contracts;
using GTS.TodoApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GTS.TodoApp.Infrastructure.Persistence.Repositories
{
    public class TodoRepository(AppDbContext _dbContext) : ITodoRepository
    {
        public async Task<IEnumerable<Todo>> GetTodosAsyc()
        {
            return await _dbContext.Set<Todo>().ToListAsync();
        }

        public async Task<Todo?> GetTodoById(Guid id)
        {
            return await _dbContext.Set<Todo>().FindAsync(id);
        }

        public async Task<bool> CreateTodo(Todo todo)
        {
            var result = await _dbContext.AddAsync(todo);

            return result.State is EntityState.Added;
        }

        public bool UpdateTodo(Todo todo)
        {
            var result = _dbContext.Update(todo);

            return result.State is EntityState.Modified;
        }

        public bool DeleteTodo(Todo todo)
        {
            var result = _dbContext.Remove(todo);
            return result.State is EntityState.Deleted;
        }
    }
}
