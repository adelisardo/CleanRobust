namespace CleanRobust.Application.Common;

public class Result
{
    public bool IsSuccess { get; init; }
    public bool IsFail => !IsSuccess;
    public string Message { get; init; }

    public Result() => IsSuccess = true;
    public Result(string message)
    {
        IsSuccess = false;
        Message = message;
    }
    public static Result Success() => new();
    public static Result Fail(string message) => new(message);
}
