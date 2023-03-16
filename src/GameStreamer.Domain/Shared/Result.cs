namespace GameStreamer.Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException("You chose incorrect Result status: Success Result must be without any Errors");
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException("You chose incorrect Result status: Not success Result must be with any Error");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    
    public static Result Success() => new Result(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);

    public static Result<TValue> Create<TValue>(TValue value, Error error)
        where TValue : class
        => value is null ? Failure<TValue>(error) : Success(value);

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default!, false, error);
}