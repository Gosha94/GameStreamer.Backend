using GameStreamer.Domain.Entities.Rooms;

namespace GameStreamer.Domain.Repositories;

public interface IRoomRepository
{
    void Add(Room room);

    Task<Room?> GetByIdWithCreatorAsync(Guid roomId, CancellationToken cancellationToken);
}