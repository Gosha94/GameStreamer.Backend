using GameStreamer.Models.Common;

namespace GameStreamer.Application.Turns.TurnDone;

public record TurnDoneEvent
{
    public Guid RoomGuid { get; init; }

    public Guid PlayerGuid { get; init; }

    public Coordinate BigAreaCoordinates { get; init; }

    public Coordinate SmallAreaCoordinates { get; init; }

    public GameFraction GameFraction { get; init; }
}