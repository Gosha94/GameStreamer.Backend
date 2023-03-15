using GameStreamer.Domain.Shared;
using GameStreamer.Domain.Repositories;
using GameStreamer.Application.Abstractions.Messaging;

namespace GameStreamer.Application.Incomers.Queries.GetIncomerById;

internal sealed class GetIncomerByIdQueryHandler : IQueryHandler<GetIncomerByIdQuery, IncomerResponse>
{

    private readonly IIncomerRepository _incomerRepository;

    public GetIncomerByIdQueryHandler(
        IIncomerRepository incomerRepository)
    {
        _incomerRepository = incomerRepository;
    }

    public async Task<Result<IncomerResponse>> Handle(
        GetIncomerByIdQuery request,
        CancellationToken cancellationToken)
    {
        var incomer = await _incomerRepository.GetByIdAsync(
            request.IncomerId,
            cancellationToken);

        if (incomer is null)
        {
            return Result.Failure<IncomerResponse>(new Error(
                "Incomer.NotFound",
                $"The incomer with Id {request.IncomerId} was not found"));
        }

        var response = new IncomerResponse(incomer.Id, incomer.NickName.Value);
        
        return response;
    }
}