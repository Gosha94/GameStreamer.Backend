using MediatR;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> 
    : IRequestHandler<TQuery, Result<TResponse>> 
    where TQuery : IQuery<TResponse>
{ }