using GameStreamer.Domain.Entities;

namespace GameStreamer.Domain.Repositories;

public interface IIncomerRepository
{
    Task<Incomer?> GetByIdAsync(Guid incomerId, CancellationToken cancellationToken);
    
    void Add(Incomer incomer);
}