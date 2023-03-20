using GameStreamer.Domain.Entities.Incomers;
using GameStreamer.Domain.Entities.Rooms;

namespace GameStreamer.Domain.Repositories;

public interface IEmailService
{
    Task SendInvitationAcceptedEmailAsync(Guid creatorId);
    Task SendInvitationSentEmailAsync(Incomer incomer, Room room, CancellationToken cancellationToken);
}