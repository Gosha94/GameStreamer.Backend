using GameStreamer.Domain.Entities.Incomers;
using GameStreamer.Domain.Repositories;

namespace GameStreamer.Infrastructure.Repositories;

internal sealed class IncomerRepository : IIncomerRepository
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