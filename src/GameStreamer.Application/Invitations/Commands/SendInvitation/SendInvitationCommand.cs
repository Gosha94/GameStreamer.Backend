using GameStreamer.Application.Abstractions.Messaging;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Invitations.Commands.SendInvitation;

public sealed record SendInvitationCommand() : ICommand<Result>
{
    public Guid IncomerId { get; init; }

    public Guid RoomId { get; init; }
}