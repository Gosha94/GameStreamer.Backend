using GameStreamer.Domain.Enums;
using GameStreamer.Domain.Primitives;
using GameStreamer.Domain.Entities.Incomers;

namespace GameStreamer.Domain.Entities.Rooms
{

    public sealed class Invitation : Entity
    {
        public Guid IncomerId { get; }

        public Guid RoomId { get; }
        
        public InvitationStatus Status { get; private set; }
        
        public DateTime CreatedOnUtc { get; }
        
        public DateTime? ModifiedOnUtc { get; private set; }

        private Invitation(Guid id, Incomer incomer, Room room) : base(id)
        {
            IncomerId = incomer.Id;
            RoomId = room.Id;
            Status = InvitationStatus.Pending;
            CreatedOnUtc = DateTime.UtcNow;
        }

        public static Invitation Create(Incomer incomer, Room room)
        {
            return new Invitation(Guid.NewGuid(), incomer, room);
        }

        internal void Expire()
        {
            Status = InvitationStatus.Expired;
            ModifiedOnUtc = DateTime.UtcNow;
        }

        internal Roomie Accept()
        {
            Status = InvitationStatus.Accepted;
            ModifiedOnUtc = DateTime.UtcNow;

            var roomie = Roomie.Create(this);

            return roomie;
        }

    }
}