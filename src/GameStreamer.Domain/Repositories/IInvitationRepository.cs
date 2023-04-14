using GameStreamer.Domain.Entities;

namespace GameStreamer.Domain.Repositories;

public interface IInvitationRepository
{
    void Add(Invitation invitation);
}