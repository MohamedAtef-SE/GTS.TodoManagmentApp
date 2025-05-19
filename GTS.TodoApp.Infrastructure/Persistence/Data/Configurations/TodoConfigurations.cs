using Microsoft.EntityFrameworkCore;
using GTS.TodoApp.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GTS.TodoApp.Infrastructure.Persistence.Data.Configurations
{
    internal class TodoConfigurations : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.Property(t => t.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd(); // for Generating Guid Id 

            builder.Property(t => t.Title)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
