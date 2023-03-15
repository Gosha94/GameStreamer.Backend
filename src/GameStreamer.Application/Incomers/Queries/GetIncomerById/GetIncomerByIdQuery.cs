using GameStreamer.Application.Abstractions.Messaging;

namespace GameStreamer.Application.Incomers.Queries.GetIncomerById;

public sealed record GetIncomerByIdQuery(Guid IncomerId) : IQuery<IncomerResponse>;