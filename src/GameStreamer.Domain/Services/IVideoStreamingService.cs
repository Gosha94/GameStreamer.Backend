namespace GameStreamer.Domain.Services
{
    public interface IVideoStreamingService
    {
        Task<Stream> GetVideoStreamAsync();
    }
}
