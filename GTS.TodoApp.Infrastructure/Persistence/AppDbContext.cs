using GTS.TodoApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GTS.TodoApp.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
