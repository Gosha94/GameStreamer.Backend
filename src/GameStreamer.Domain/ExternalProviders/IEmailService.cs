using GameStreamer.Domain.Entities;

namespace GameStreamer.Domain.ExternalProviders;

public interface IEmailService
{
    Task SendInvitationAcceptedEmailAsync(Guid creatorId);
    Task SendInvitationSentEmailAsync(Incomer incomer, Room room, CancellationToken cancellationToken);
}