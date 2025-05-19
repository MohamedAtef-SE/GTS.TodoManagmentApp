using GTS.TodoApp.Core.Application.Abstraction.Services;

namespace GTS.TodoApp.Core.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITodoService> _todoService;
        public ServiceManager(Func<ITodoService> todoService)
        {
            _todoService = new Lazy<ITodoService>(todoService,LazyThreadSafetyMode.ExecutionAndPublication);
        }
        public ITodoService TodoService => _todoService.Value;
    }
}
