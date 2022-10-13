namespace Bodegas.Domain.Helpers
{
    public class ApiAliadosResponse
    {
        public string? Message { get; set; } = default!;
        public string? ExceptionType { get; set; } = default!;

        public ApiAliadosResponse(string message)
        {
            Message = message;
        }
    }
}
