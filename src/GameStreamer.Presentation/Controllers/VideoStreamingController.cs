using GameStreamer.Domain.Repositories;
using GameStreamer.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStreamer.Presentation.Controllers
{

    [RequireHttps]
    [Route("api/videostream")]
    public sealed class VideoStreamingController : ApiController
    {
        
        private readonly IVideoStreamingService _streamingService;

        public VideoStreamingController(IMediator sender, IVideoStreamingService streamingService) : base(sender)
        {
            _streamingService = streamingService;
        }

        [HttpGet]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetVideoStreamAsync();
            return new FileStreamResult(stream, "video/mp4");
        }

    }
}
