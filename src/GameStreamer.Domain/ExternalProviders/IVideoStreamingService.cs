namespace GameStreamer.Domain.ExternalProviders;

public interface IVideoStreamingService
{
    Task<Stream> GetVideoStreamAsync();
}
