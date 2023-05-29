using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameStreamer.Domain.Shared;
using GameStreamer.Presentation.Abstractions;
using GameStreamer.Application.Incomers.Commands.CreateIncomer;
using GameStreamer.Application.Incomers.Queries.GetIncomerById;

namespace GameStreamer.Presentation.Controllers;

[RequireHttps]
[Route("api/incomers")]
public sealed class IncomersController : ApiController
{

    public IncomersController(IMediator sender)
        : base(sender)
    { }

    [HttpPost]
    public async Task<IActionResult> RegisterIncomer(CancellationToken cancellationToken)
    {
        var command = new CreateIncomerCommand(
            "Test_NickName");

        var result = await Sender.Send(command, cancellationToken);
        
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIncomerById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetIncomerByIdQuery(id);

        Result<IncomerResponse> response = await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

}