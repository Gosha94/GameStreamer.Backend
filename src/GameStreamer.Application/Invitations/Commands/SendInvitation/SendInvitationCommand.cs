using GameStreamer.Application.Abstractions.Messaging;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Invitations.Commands.SendInvitation;

public sealed record SendInvitationCommand(Guid IncomerId, Guid RoomId) : ICommand<Result>;