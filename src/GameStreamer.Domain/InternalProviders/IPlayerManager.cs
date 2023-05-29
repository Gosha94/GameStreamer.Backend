using GameStreamer.DTOs;
using GameStreamer.DTOs.DataAccess;

namespace GameStreamer.Domain.InternalProviders;

public interface IPlayerManager
{

    public PlayerDataResponseDTO MakePlayerReadyToGame(string connectionId);

    public PlayerDataResponseDTO SetMatchTypeToPlayer(string connectionId, bool matchType);

    public PlayerDataResponseDTO ChangePlayerNickName(string prevNickName, string newNickName);

    public PlayerDataResponseDTO? AddNewPlayer(PlayerDto addedPlayerDto);

    public PlayerDataResponseDTO RemovePlayer(string connectionId);

    //public PlayerDataResponseDTO GetRandomPlayer();

    //public IEnumerable<PlayerDataResponseDTO> GetAllPlayersWithoutRoom();

}
