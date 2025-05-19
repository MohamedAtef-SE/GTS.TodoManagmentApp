using GTS.TodoApp.Core.Domain.Entities._Common;
using System.ComponentModel.DataAnnotations;

namespace GTS.TodoApp.Shared.DTOs
{
    public class TodoDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title cannot more than 100 characters")]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string Status { get; set; } = SD_Status.Pending;
        public string Priority { get; set; } = SD_Priority.Medium;

        [DataType(DataType.Date)]
        [Range(typeof(DateOnly), "2025-01-01", "2100-12-31")]
        public DateOnly? DueDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;

    }
}
