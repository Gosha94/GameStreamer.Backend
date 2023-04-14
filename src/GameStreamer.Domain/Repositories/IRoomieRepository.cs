using GameStreamer.Domain.Entities;

namespace GameStreamer.Domain.Repositories;

public interface IRoomieRepository
{
    void Add(Roomie roomie);
}