namespace GTS.TodoApp.Core.Application.Abstraction.Services
{
    public interface IServiceManager
    {
        ITodoService TodoService { get; }
    }
}
