using GameStreamer.Domain.Entities;
using GameStreamer.Domain.Entities.Rooms;

namespace GameStreamer.Domain.Services;

public interface IEmailService
{
    Task SendInvitationAcceptedEmailAsync(Guid creatorId);
    Task SendInvitationSentEmailAsync(Incomer incomer, Room room, CancellationToken cancellationToken);
}