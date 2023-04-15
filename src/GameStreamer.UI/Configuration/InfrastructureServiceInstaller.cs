using GameStreamer.Consumers;
using GameStreamer.Consumers.Definitions;
using GameStreamer.Domain.Repositories;
using GameStreamer.Infrastructure.Repositories;
using GameStreamer.Services;
using MassTransit;

namespace GameStreamer.UI.Configuration
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRoomManager, RoomManager>();
            services.AddTransient<IGameStreamRepository, GameStreamRepository>();
            services.AddSingleton<IPlayerManager, PlayerManager>();
            services.AddSingleton<IHashService, HashService>();

            services.AddMassTransit(x =>
            {

                x.AddConsumer<TurnAcceptedConsumer>(typeof(TurnAcceptedConsumerDefinition));
                x.AddConsumer<TurnDeniedConsumer>(typeof(TurnNotAcceptedConsumerDefinition));

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((rmqContext, cfg) =>
                {
                    cfg.Host("localhost", "xo_game", h =>
                    {
                        h.Username("xo_admin");
                        h.Password("xo_admin");
                    });

                    cfg.ConfigureEndpoints(rmqContext);
                });

            });
        }
    }
}
