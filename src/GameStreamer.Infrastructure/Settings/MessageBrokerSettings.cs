namespace GameStreamer.Infrastructure.Settings;

public sealed class MessageBrokerSettings
{
    public string Host { get; set; } = string.Empty;

    public int Port { get; set; } = 0;

    public string VirtualHost { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

}
