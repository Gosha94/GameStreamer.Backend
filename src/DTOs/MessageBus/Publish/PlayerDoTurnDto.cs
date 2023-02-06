﻿using GameStreamer.Backend.Models.Common;

namespace GameStreamer.Backend.DTOs.MessageBus.Publish
{
    public class PlayerDoTurnDto
    {
        public Guid RoomGuid { get; set; }

        public Guid PlayerGuid { get; set; }

        public Coordinate BigAreaCoordinates { get; set; }

        public Coordinate SmallAreaCoordinates { get; set; }

        public GameFraction GameFraction { get; set; }
    }

}