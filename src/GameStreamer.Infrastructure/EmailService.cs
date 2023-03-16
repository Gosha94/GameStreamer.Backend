using GameStreamer.Domain.Entities;
using GameStreamer.Domain.Repositories;

namespace GameStreamer.Infrastructure;

internal sealed class EmailService : IEmailService
{
    public Task SendInvitationAcceptedEmailAsync(Guid creatorId)
    {
        throw new NotImplementedException();
    }

    public Task SendInvitationSentEmailAsync(Incomer incomer, Room room, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}