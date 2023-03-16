using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStreamer.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("GameStreamerServiceDatabase_Local");

        services.AddDbContext<GameStreamerDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql(connectionString);
        });

        return services;
    }

}