namespace MyPrj.Application.ViewModel;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = "";
    public string? StackTrace { get; set; }
}