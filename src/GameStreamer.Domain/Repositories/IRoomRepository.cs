using GameStreamer.Domain.Entities;

namespace GameStreamer.Domain.Repositories;

public interface IRoomRepository
{
    void Add(Room room);

    Task<Room?> GetByIdWithCreatorAsync(Guid roomId, CancellationToken cancellationToken);
}