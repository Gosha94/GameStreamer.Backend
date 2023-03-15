namespace GameStreamer.UI.Configuration
{
    public class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers()
                .AddApplicationPart(GameStreamer.Presentation.AssemblyReference.Assembly);

            services.AddSwaggerGen();
        }
    }
}