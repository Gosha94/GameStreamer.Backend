namespace GameStreamer.Application.Incomers.Commands.CreateIncomer;

public sealed record CreatedIncomerResponse(Guid Id = default(Guid), string NickName = "");