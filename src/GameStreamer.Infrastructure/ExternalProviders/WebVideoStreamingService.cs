using GameStreamer.Domain.ExternalProviders;

namespace GameStreamer.Infrastructure.ExternalProviders;

public sealed class WebVideoStreamingService : IVideoStreamingService, IDisposable
{

    private readonly HttpClient _httpClient;
    private const string VIDEO_URL = "https://anthonygiretti.blob.core.windows.net/videos/earth.mp4";


    public WebVideoStreamingService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Stream> GetVideoStreamAsync()
    {
        return await _httpClient.GetStreamAsync(VIDEO_URL);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}