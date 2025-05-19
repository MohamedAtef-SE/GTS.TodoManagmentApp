namespace GTS.TodoApp.Core.Domain.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public string Priority { get; set; } = null!;
        public DateOnly? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set;}

    }
}
