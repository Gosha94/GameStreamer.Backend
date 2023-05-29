using GameStreamer.Domain.Shared;
using GameStreamer.Application.Abstractions.Messaging;

namespace GameStreamer.Application.Incomers.Commands.CreateIncomer;

public sealed record CreateIncomerCommand(string NickName = "") : ICommand<Result>;