namespace GameStreamer.Domain.Entities;

public sealed class Roomie
{

    public Guid IncomerId { get; }

    public Guid RoomId { get; }

    public DateTime CreatedOnUtc { get; }
    
    private Roomie(Invitation invitation)
    {
        IncomerId = invitation.IncomerId;
        RoomId = invitation.RoomId;
        CreatedOnUtc = DateTime.UtcNow;
    }
    
    public static Roomie Create(Invitation invitation)
    {
        return new Roomie(invitation);
    }

}