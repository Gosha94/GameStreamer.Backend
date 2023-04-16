using MassTransit;
using GameStreamer.Consumers;
using GameStreamer.Domain.Repositories;
using GameStreamer.Domain.InternalProviders;
using GameStreamer.Infrastructure.InternalProviders;
using GameStreamer.Infrastructure.Storage.Repositories;
using GameStreamer.Infrastructure.MessageBroker.Consumers.Definitions;

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

                x.AddConsumer<TurnAcceptedEventConsumer>(typeof(TurnAcceptedConsumerDefinition));
                x.AddConsumer<TurnDeniedEventConsumer>(typeof(TurnNotAcceptedConsumerDefinition));

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
