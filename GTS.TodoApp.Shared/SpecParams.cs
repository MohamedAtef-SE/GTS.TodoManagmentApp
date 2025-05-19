namespace GTS.TodoApp.Core.Application.Specifications
{
    public class SpecParams
    {
        public string? Title { get; set; } 
        public string? Status { get; set; }
        public string? Priority { get; set; }
        public DateTime? startingDate { get; set; }
        public DateTime? endingDate { get; set; }
        public string? Sort { get; set; }
    }
}
