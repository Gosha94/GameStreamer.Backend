using GameStreamer.Domain.Entities;
using GameStreamer.Domain.Repositories;
using GameStreamer.Infrastructure.Storage;

namespace GameStreamer.Infrastructure.Storage.Repositories;

public sealed class IncomerRepository : IIncomerRepository
{

    private readonly GameStreamerDbContext _dbContext;

    public IncomerRepository(GameStreamerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Incomer?> GetByIdAsync(Guid incomerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Add(Incomer incomer)
    {
        throw new NotImplementedException();
    }
}