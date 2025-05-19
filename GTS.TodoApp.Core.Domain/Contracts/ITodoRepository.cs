using GTS.TodoApp.Core.Domain.Entities;

namespace GTS.TodoApp.Core.Domain.Contracts
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodosAsyc();
        Task<Todo?> GetTodoById(Guid id);
        Task<bool> CreateTodo(Todo todo);
        bool UpdateTodo(Todo todo);
        bool DeleteTodo(Todo id);
    }
}
