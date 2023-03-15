using MediatR;

namespace GameStreamer.Application.Rooms.Commands.CreateRoom;

public sealed record CreateRoomCommand(
    Guid IncomerId,
    string RoomName,
    int? MaximumNumberOfRoomies
    ) : IRequest<Unit>;