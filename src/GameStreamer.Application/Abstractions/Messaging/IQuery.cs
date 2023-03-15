using MediatR;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }