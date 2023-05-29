namespace GameStreamer.Application.Turns.TurnDenied
{
    public class TurnDeniedDto
    {
        public Guid RoomGuid { get; set; }

        public Guid PlayerGuid { get; set; }
    }
}