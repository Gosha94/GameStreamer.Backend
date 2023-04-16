using GameStreamer.Application.Abstractions.Messaging;
using GameStreamer.Domain.Entities;

namespace GameStreamer.Application.Incomers.Queries.GetIncomerById;

public sealed record GetIncomerByIdQuery(Guid IncomerId = default(Guid)) : IQuery<IncomerResponse>;