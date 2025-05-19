using GTS.TodoApp.Core.Application.Abstraction.Services;
using GTS.TodoApp.Core.Application.Mapping;
using GTS.TodoApp.Core.Application.Services;
using GTS.TodoApp.Core.Domain.Contracts.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace GTS.TodoApp.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, GTS.TodoApp.Core.Application.UnitOfWork.UnitOfWork>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<Func<ITodoService>>(serviceProvider =>
            {
                return () => serviceProvider.GetRequiredService<ITodoService>();
            });

            return services;
        }
    }
}
