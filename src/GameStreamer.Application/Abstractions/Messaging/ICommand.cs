using MediatR;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{ }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{ }