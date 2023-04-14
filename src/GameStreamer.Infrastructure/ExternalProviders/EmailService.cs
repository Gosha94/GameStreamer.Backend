﻿using GameStreamer.Domain.Entities;
using GameStreamer.Domain.Entities.Rooms;
using GameStreamer.Domain.Services;

namespace GameStreamer.Infrastructure.ExternalProviders;

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