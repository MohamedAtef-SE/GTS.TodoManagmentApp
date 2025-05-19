namespace GTS.TodoApp.Shared
{
    public class ValidationErrorHandling
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();

    }
}
