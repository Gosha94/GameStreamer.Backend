using GameStreamer.Domain.Shared;
using GameStreamer.Domain.Primitives;

namespace GameStreamer.Domain.ValueObjects;

public sealed class RoomName : ValueObject
{
    public const int MaxLength = 25;

    private RoomName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<RoomName> Create(string roomName)
    {
        if (string.IsNullOrWhiteSpace(roomName))
        {
            return Result.Failure<RoomName>(new Error(
                "RoomName.Empty",
                "RoomName is empty."));
        }

        if (roomName.Length > MaxLength)
        {
            return Result.Failure<RoomName>(new Error(
                "RoomName.TooLong",
                "RoomName is too long."));
        }

        return new RoomName(roomName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}