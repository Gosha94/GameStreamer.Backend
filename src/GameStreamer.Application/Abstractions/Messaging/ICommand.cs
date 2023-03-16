using MediatR;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{ }