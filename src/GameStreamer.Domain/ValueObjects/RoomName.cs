using GameStreamer.Domain.Shared;
using GameStreamer.Domain.Primitives;
using GameStreamer.Domain.Errors;

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
            return Result.Failure<RoomName>(DomainErrors.EmptyRoomName);
        }

        if (roomName.Length > MaxLength)
        {
            return Result.Failure<RoomName>(DomainErrors.TooLongRoomName);
        }

        return new RoomName(roomName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}