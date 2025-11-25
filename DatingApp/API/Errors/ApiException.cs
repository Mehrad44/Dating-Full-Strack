namespace API.Errors
{
    public class ApiException(int statueCOde, string message, string? details)
    {
        public int StatueCode { get; set; } = statueCOde;

        public string Message { get; set; } = message;

        public string? Details { get; set; } = details;

    }
}
