namespace GameStreamer.Interfaces
{
    public interface IGameHub
    {
        Task TestBroadcastPublish(string message);

        Task GameIsStarted();
    }
}
