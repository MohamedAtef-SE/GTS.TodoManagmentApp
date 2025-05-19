using GTS.TodoApp.Core.Application.Specifications;
using GTS.TodoApp.Shared.Helpers;
using GTS.TodoApp.Shared.DTOs;

namespace GTS.TodoApp.Core.Application.Abstraction.Services
{
    public interface ITodoService
    {
        Task<Result<IEnumerable<TodoDTO>>> GetAllWithSpecsAsync(SpecParams specParams);
        Task<Result<TodoDTO>> GetTodoByIdAsync(Guid id);
        Task<Result<TodoDTO>> CreateTodoAsync(TodoDTO todoDTO);
        Task<Result<TodoDTO>> UpdateTodo(TodoDTO todoDTO);
        Task<Result<bool>> DeleteTodo(TodoDTO todoDTO);
        Task<Result<string>> MarkAsCompleted(Guid id);
    }
}
