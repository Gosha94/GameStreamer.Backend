using GameStreamer.Application.Abstractions.Messaging;

namespace GameStreamer.Application.Incomers.Commands.CreateIncomer;

public sealed record CreateIncomerCommand(string NickName) : ICommand<Guid>;