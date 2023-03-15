using MediatR;

namespace GameStreamer.Application.Invitations.Commands.AcceptInvitation;

public sealed record AcceptInvitationCommand(Guid RoomId, Guid InvitationId) : IRequest<Unit>;