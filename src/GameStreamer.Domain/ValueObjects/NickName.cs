using GameStreamer.Domain.Shared;
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
            return Result.Failure<NickName>(new Error(
                "NickName.Empty",
                "NickName is empty."));
        }

        if (nickName.Length > MaxLength)
        {
            return Result.Failure<NickName>(new Error(
                "NickName.TooLong",
                "NickName is too long."));
        }

        return new NickName(nickName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}