using GameStreamer.Application.Incomers.Commands.CreateIncomer;
using GameStreamer.Application.Incomers.Queries.GetIncomerById;
using GameStreamer.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameStreamer.Presentation.Abstractions;

namespace GameStreamer.Presentation.Controllers;

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

        Result<IncomerResponse> response = (Result<IncomerResponse>)await Sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : NotFound(response.Error);
    }

}