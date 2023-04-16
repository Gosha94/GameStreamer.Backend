using MediatR;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Rooms.Commands.CreateRoom;

public sealed record CreateRoomCommand() : IRequest<Result>
{
    public Guid IncomerId { get; init; }

    public string RoomName { get; init; } = string.Empty;

    public int? MaximumNumberOfRoomies { get; init; }
}