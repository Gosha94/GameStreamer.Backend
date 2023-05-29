using GameStreamer.Domain.InternalProviders;
using GameStreamer.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace GameStreamer.Hubs
{
    public class RoomsHub : Hub<IRoomsHub>
    {

        //private readonly IRoomManager _roomManager;
        //private readonly IPlayerManager _playerManager;
        //private readonly IPublishEndpoint _publishEndpoint;

        //public RoomsHub(IRoomManager roomManager, IPlayerManager playerManager)
        //{
        //    _roomManager = roomManager;
        //    _playerManager = playerManager;
        //}

        public Task GreetNewPlayer(string nickName)
        {

            //var playerDto = new PlayerDto(nickName);
            //playerDto.RoomHubId = Context.ConnectionId;
            //playerDto.IsRandomGameMode = true;

            //var responseData = _playerManager.AddNewPlayer(playerDto);

            //var gameRoomsList = _roomManager.GetAllGameRooms();

            //var playersWithoutRoomList = _playerManager.GetAllPlayersWithoutRoom();

            //Clients.AllExcept(Context.ConnectionId).NewPlayerJoined(responseData);
            Clients.AllExcept(Context.ConnectionId).NewPlayerJoined(new PlayerDataResponseDTO { ConnectionId = "123", NickName = "RandonPlayer" });
            //Clients.Caller.UpdatePlayersWithoutRooms(playersWithoutRoomList);

            return Task.CompletedTask;
        }

        public Task PlayerChangedLogin(string prevLogin, string actualLogin)
        {
            //var changedPlayerDataDto = _playerManager.ChangePlayerNickName(prevLogin, actualLogin);

            //Clients.All.PlayerChangedNickName(changedPlayerDataDto);
            Clients.All.PlayerChangedNickName(new PlayerDataResponseDTO { ConnectionId = "123", NickName = "RandonPlayer" });
            
            return Task.CompletedTask;
        }

        public Task PlayerChoseRandomGame()
        {
            return Task.CompletedTask;
        }

        public Task PlayerChoseStandardGame() => Task.CompletedTask;

        public override Task OnDisconnectedAsync(Exception? exception)
        {

            //var removedPlayerDto = _playerManager.RemovePlayer(Context.ConnectionId);
            
            //Clients.AllExcept(Context.ConnectionId).PlayerLeavedServer(removedPlayerDto);
            Clients.AllExcept(Context.ConnectionId).PlayerLeavedServer(new PlayerDataResponseDTO { ConnectionId = "123", NickName = "RandonPlayer" });

            return base.OnDisconnectedAsync(exception);
        }

    }
}