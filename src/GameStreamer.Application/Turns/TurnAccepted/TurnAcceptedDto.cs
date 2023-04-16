namespace GameStreamer.Application.Turns.TurnAccepted
{
    public class TurnAcceptedDto
    {
        public Guid RoomGuid { get; set; }

        public Guid PlayerGuid { get; set; }
    }
}