using GameStreamer.Consumers;
using GameStreamer.Consumers.Definitions;
using GameStreamer.Domain.Repositories;
using GameStreamer.Infrastructure.Repositories;
using GameStreamer.Services;
using MassTransit;

namespace GameStreamer.UI.Configuration
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {   }
    }
}