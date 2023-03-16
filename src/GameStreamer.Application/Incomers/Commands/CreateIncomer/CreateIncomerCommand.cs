using GameStreamer.Application.Abstractions.Messaging;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Incomers.Commands.CreateIncomer;

public sealed record CreateIncomerCommand(string NickName) : ICommand<Result>;