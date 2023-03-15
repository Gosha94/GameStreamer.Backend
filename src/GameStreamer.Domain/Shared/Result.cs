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

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => (Result<TValue>)Success();

    public static Result<TValue> Failure<TValue>(Error error) => (Result<TValue>)Failure(error);

    public static Result<TValue> Create<TValue>(TValue? value)
    {
        if (value is null)
        {
            return Failure<TValue>(Error.NullValue);
        }

        return Success<TValue>(value);
    }

    

}