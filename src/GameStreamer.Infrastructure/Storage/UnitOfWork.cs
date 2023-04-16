using GameStreamer.Domain.Repositories;

namespace GameStreamer.Infrastructure.Storage;

public sealed class UnitOfWork : IUnitOfWork
{

    private readonly GameStreamerDbContext _dbContext;

    public UnitOfWork(GameStreamerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancelToken = default)
    {
        return _dbContext.SaveChangesAsync(cancelToken);
    }
}