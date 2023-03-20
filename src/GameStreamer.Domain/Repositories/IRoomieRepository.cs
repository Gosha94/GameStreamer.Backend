using GameStreamer.Domain.Entities.Rooms;

namespace GameStreamer.Domain.Repositories;

public interface IRoomieRepository
{
    void Add(Roomie roomie);
}