using MediatR;

namespace GameStreamer.Application.Invitations.Commands.AcceptInvitation;

public sealed record AcceptInvitationCommand() : IRequest<Unit>
{
    public Guid RoomId { get; init; }

    public Guid InvitationId { get; init; }
}