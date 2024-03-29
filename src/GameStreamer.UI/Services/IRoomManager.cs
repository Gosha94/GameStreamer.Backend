﻿using GameStreamer.DTOs;

namespace GameStreamer.Services
{

    /// <summary>
    /// Интерфейс сервиса управления игровыми комнатами
    /// </summary>
    public interface IRoomManager
    {

        public GameRoomResponseDTO RemoveRoom(string roomName);

        public GameRoomResponseDTO AddRoom(string roomName);

        public GameRoomResponseDTO GetRandomRoom();

        public List<GameRoomResponseDTO> GetAllGameRooms();

    }
}