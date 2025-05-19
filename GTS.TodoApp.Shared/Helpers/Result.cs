namespace GTS.TodoApp.Shared.Helpers
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string>? Errors { get; set; }
        public T? Value { get; set; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, Value = value };
        public static Result<T> Failure(string errorMessage) => new Result<T> { IsSuccess = false, ErrorMessage = errorMessage };
    }
}
