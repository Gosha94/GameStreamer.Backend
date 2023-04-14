using GameStreamer.Domain.Errors;
using GameStreamer.Domain.Shared;
using GameStreamer.Domain.Primitives;
using GameStreamer.Domain.ValueObjects;

namespace GameStreamer.Domain.Entities
{
    public sealed class Room : AggregateRoot
    {

        private readonly List<Roomie> _roomies = new();
        public IReadOnlyCollection<Roomie> Roomies => _roomies;

        private readonly List<Invitation> _invitations = new();
        public IReadOnlyCollection<Invitation> Invitations => _invitations;

        public Incomer Creator { get; }

        public RoomName RoomName { get; }

        public int MaxRoomiesNumber { get; }

        public DateTime CreatedOnUtc { get; }

        private int _currentRoomiesNumber;

        private Room(
            Guid id,
            Incomer creator,
            string roomName,
            int maxRoomiesNumber
        ) : base(id)
        {
            RoomName = RoomName.Create(roomName).Value;
            Creator = creator;
            CreatedOnUtc = DateTime.UtcNow;
            MaxRoomiesNumber = maxRoomiesNumber;
        }

        public static Room Create(Guid id, Incomer creator, string name)
        {
            var maxNumberOfRoomies = 2;

            var room = new Room(Guid.NewGuid(), creator, name, maxNumberOfRoomies);

            return room;
        }

        public Result<Invitation> SendInvitation(Incomer incomer)
        {

            if (Creator.Id == incomer.Id)
            {
                return Result.Failure<Invitation>(DomainErrors.CreatorInviting);
            }

            var invitation = Invitation.Create(incomer, this);

            _invitations.Add(invitation);

            return invitation;
        }

        public Result<Roomie?> AcceptInvitation(Invitation invitation)
        {

            if (_currentRoomiesNumber == MaxRoomiesNumber)
            {
                return Result.Failure<Roomie?>(DomainErrors.InviteToFullRoom);
            }

            var isInvitationExpired = false;

            if (isInvitationExpired)
            {
                invitation.Expire();
                return null;
            }

            var roomie = invitation.Accept();
            _roomies.Add(roomie);
            _currentRoomiesNumber++;

            return roomie;
        }

    }
}