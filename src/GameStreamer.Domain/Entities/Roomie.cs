using GameStreamer.Domain.Primitives;

namespace GameStreamer.Domain.Entities;

public sealed class Roomie : Entity
{

    public Guid IncomerId { get; }

    public Guid RoomId { get; }

    public DateTime CreatedOnUtc { get; }

    private Roomie(Guid id, Invitation invitation) : base(id)
    {
        IncomerId = invitation.IncomerId;
        RoomId = invitation.RoomId;
        CreatedOnUtc = DateTime.UtcNow;
    }

    public static Roomie Create(Invitation invitation)
    {
        return new Roomie(Guid.NewGuid(), invitation);
    }

}