using GameStreamer.Domain.Shared;
using GameStreamer.Domain.Errors;
using GameStreamer.Domain.Primitives;

namespace GameStreamer.Domain.ValueObjects;

public sealed class NickName : ValueObject
{

    public const int MaxLength = 30;

    private NickName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<NickName> Create(string nickName)
    {
        if (string.IsNullOrWhiteSpace(nickName))
        {
            return Result.Failure<NickName>(DomainErrors.EmptyNickName);
        }

        if (nickName.Length > MaxLength)
        {
            return Result.Failure<NickName>(DomainErrors.TooLongNickName);
        }

        return new NickName(nickName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}