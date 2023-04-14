using MassTransit;

namespace GameStreamer.UI.Configuration
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {

            services.AddSignalR();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

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