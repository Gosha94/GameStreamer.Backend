namespace GameStreamer.Domain.Repositories
{
    public interface IVideoStreamingService
    {
        Task<Stream> GetVideoStreamAsync();
    }
}
