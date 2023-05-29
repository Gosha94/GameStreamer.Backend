using Microsoft.EntityFrameworkCore;

namespace GameStreamer.Infrastructure.Storage;

public sealed class GameStreamerDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameStreamerDbContext"/> class.
    /// </summary>
    /// <param name="options">The database context options.</param>
    /// <param name="modelBuilder"></param>
    public GameStreamerDbContext(DbContextOptions options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameStreamerDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    /// <summary>
    /// Saves all of the pending changes in the unit of work.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}