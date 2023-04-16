namespace GameStreamer.Domain.InternalProviders;

public interface IGameHub
{
    Task TestBroadcastPublish(string message);

    Task GameIsStarted();
}
