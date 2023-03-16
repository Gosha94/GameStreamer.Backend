using GameStreamer.Models.Common;

namespace GameStreamer.DTOs.GameClient
{
    public class PlayerMadeTurnDto
    {

        public Coordinate SmallAreaCoordinates { get; set; }

        public Coordinate CellCoordinates { get; set; }

    }
}