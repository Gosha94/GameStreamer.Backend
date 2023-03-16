using Hangfire;

namespace GameStreamer.UI.Configuration
{
    public class BackgroundJobsServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<ICustomJobService, CustomJobService>();

            //services.AddHangfire(config =>
            //    config.UsePostgreSqlStorage("Host=localhost;Database=local;"));

            //services.AddHangfireServer();
        }
    }
}