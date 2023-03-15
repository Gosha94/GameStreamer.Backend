using MediatR;

namespace GameStreamer.Application.Invitations.Commands.SendInvitation;

public sealed record SendInvitationCommand(Guid IncomerId, Guid RoomId) : IRequest<Unit>;