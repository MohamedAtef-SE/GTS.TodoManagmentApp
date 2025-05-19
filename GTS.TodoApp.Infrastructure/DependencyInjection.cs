using GTS.TodoApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace GTS.TodoApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((provider,options) =>
           
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))

            );
            return services;
        }
    }
}
