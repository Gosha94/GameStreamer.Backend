namespace GameStreamer.Application.Incomers.Queries.GetIncomerById;

public sealed record IncomerResponse(Guid Id = default, string NickName = "");