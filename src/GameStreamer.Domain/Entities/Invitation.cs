using GameStreamer.Domain.Enums;

namespace GameStreamer.Domain.Entities
{

    public sealed class Invitation
    {
        public Guid Id { get; }
        public Guid IncomerId { get; }
        public Guid RoomId { get; }
        public InvitationStatus Status { get; private set; }
        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; private set; }

        private Invitation(Guid id, Incomer incomer, Room room)
        {
                Id = id;
                IncomerId = incomer.Id;
                RoomId = room.Id;
                Status = InvitationStatus.Pending;
                CreatedOnUtc = DateTime.UtcNow;
        }

        public static Invitation Create(Guid id, Incomer incomer, Room room)
        {
            return new Invitation(id, incomer, room);
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