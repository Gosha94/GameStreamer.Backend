using GameStreamer.Domain.Entities;
using GameStreamer.Domain.Repositories;

namespace GameStreamer.Infrastructure.Storage.Repositories;

internal sealed class RoomRepository : IRoomRepository
{
    public void Add(Room room)
    {
        throw new NotImplementedException();
    }

    public Task<Room?> GetByIdWithCreatorAsync(Guid roomId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}