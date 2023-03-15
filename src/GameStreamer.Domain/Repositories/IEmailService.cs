using GameStreamer.Domain.Entities;

namespace GameStreamer.Domain.Repositories;

public interface IEmailService
{
    Task SendInvitationAcceptedEmailAsync(Guid creatorId);
    Task SendInvitationSentEmailAsync(Incomer incomer, Room room, CancellationToken cancellationToken);
}