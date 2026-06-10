namespace SaaSPlatform.Application.Common.Models;

public class Result
{
    public bool IsSuccess { get; }

    public string? Error { get; }

    protected Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success
        => new Result(true, null);

    public static Result Failure(string error)
        => new Result(false, error);
}

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(T value)
        : base(true, null)
    {
        Value = value;
    }

    private Result(string error)
        : base(false, error)
    {

    }

    public static new Result<T> Success(T value)
    => new(value);

    public static new Result<T> Failure(string error)
        => new(error);
}
