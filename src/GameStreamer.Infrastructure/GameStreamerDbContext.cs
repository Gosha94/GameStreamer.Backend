using Microsoft.EntityFrameworkCore;

namespace GameStreamer.Infrastructure;

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

    //public new DbSet<TEntity> Set<TEntity>()
    //    where TEntity : Entity =>
    //    base.Set<TEntity>();

    //public async Task<TEntity?> GetBydIdAsync<TEntity>(Guid id)
    //    where TEntity : Entity
    //{
    //    if (id == Guid.Empty)
    //    {
    //        return null;
    //    }

    //    return await Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
    //}

    //public void Insert<TEntity>(TEntity entity)
    //    where TEntity : Entity =>
    //    Set<TEntity>().Add(entity);

    //public new void Remove<TEntity>(TEntity entity)
    //    where TEntity : Entity =>
    //    Set<TEntity>().Remove(entity);

}