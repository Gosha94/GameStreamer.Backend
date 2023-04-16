using GameStreamer.UI.Settings;
using GameStreamer.Infrastructure.Settings;

namespace GameStreamer.UI.Configuration;

public static class ConfigurationExtensions
{
    public static IConfiguration SetFromDockerComposeEnvironmentVariables(this ConfigurationManager configManager, IWebHostEnvironment env, WebApplicationBuilder builder)
    {

        var appConfiguration = configManager
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        builder.Services.Configure<MessageBrokerSettings>(builder.Configuration.GetSection("MessageBroker"));
        builder.Services.Configure<LoggerSettings>(builder.Configuration.GetSection("Logger"));

        return appConfiguration;
    }
}