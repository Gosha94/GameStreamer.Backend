using GameStreamer.Domain.Entities.Rooms;

namespace GameStreamer.Domain.Repositories;

public interface IInvitationRepository
{
    void Add(Invitation invitation);
}