using GameStreamer.Domain.Entities.Incomers;

namespace GameStreamer.Domain.Repositories;

public interface IIncomerRepository
{
    Task<Incomer?> GetByIdAsync(Guid incomerId, CancellationToken cancellationToken);
    
    void Add(Incomer incomer);
}