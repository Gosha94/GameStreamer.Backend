using MassTransit;
using GameStreamer.Domain.Repositories;
using GameStreamer.Infrastructure.Settings;
using GameStreamer.Domain.InternalProviders;
using GameStreamer.Application.Turns.TurnDenied;
using GameStreamer.Application.Turns.TurnAccepted;
using GameStreamer.Infrastructure.InternalProviders;
using GameStreamer.Infrastructure.Storage.Repositories;
using GameStreamer.Infrastructure.MessageBroker.Consumers.Definitions;
using GameStreamer.Infrastructure.MessageBroker;
using GameStreamer.Application.Abstractions.EventBus;
using GameStreamer.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Scrutor;

namespace GameStreamer.UI.Configuration
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {

            services
                .Scan(
                selector => selector
                .FromAssemblies(
                    GameStreamer.Infrastructure.AssemblyReference.Assembly)
            .AddClasses(false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsMatchingInterface()
            .WithScopedLifetime());

            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IGameStreamRepository, GameStreamRepository>();
            
            //services.AddTransient<IIncomerRepository, IncomerRepository>();
            //services.AddTransient<IInvitationRepository, InvitationRepository>();
            //services.AddTransient<IRoomieRepository, RoomieRepository>();
            //services.AddTransient<IRoomRepository, RoomRepository>();

            services.AddSingleton<IRoomManager, RoomManager>();            
            services.AddSingleton<IPlayerManager, PlayerManager>();
            services.AddSingleton<IHashService, HashService>();

            var connectionString = configuration.GetConnectionString("GameStreamerContext");

            services.AddDbContext<GameStreamerDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseNpgsql(connectionString);
            });

            var brokerSettings = configuration.GetSection("MessageBroker").Get<MessageBrokerSettings>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<TurnAcceptedEventConsumer>(typeof(TurnAcceptedConsumerDefinition));
                x.AddConsumer<TurnDeniedEventConsumer>(typeof(TurnNotAcceptedConsumerDefinition));

                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((rmqContext, cfg) =>
                {
                    cfg.Host(brokerSettings.Host, brokerSettings.VirtualHost, h =>
                    {
                        h.Username(brokerSettings.UserName);
                        h.Password(brokerSettings.Password);
                    });

                    cfg.ConfigureEndpoints(rmqContext);
                });
            });

            services.AddTransient<IEventBus, EventBus>();

        }
    }
}
