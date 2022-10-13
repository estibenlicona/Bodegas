namespace Bodegas.Domain.Helpers
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public bool Ok { get; set; }
        public int Count { get; set; } = 0;
        public T Body { get; set; } = default!;

        public ApiResponse(string message, bool ok)
        {
            Ok = ok;
            Message = message;
        }

    }
}
