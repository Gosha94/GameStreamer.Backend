using GameStreamer.DTOs;
using GameStreamer.DTOs.DataAccess;
using GameStreamer.Domain.Repositories;
using GameStreamer.Domain.InternalProviders;

namespace GameStreamer.Infrastructure.InternalProviders;

public class PlayerManager : IPlayerManager
{
    private readonly IHashService _hashService;
    private readonly IGameStreamRepository _gameRepo;
    private readonly Random _random = new();

    public PlayerManager(IGameStreamRepository gameRepo, IHashService hashService)
    {
        _gameRepo = gameRepo;
        _hashService = hashService;
    }

    public PlayerDataResponseDTO? AddNewPlayer(PlayerDto addedPlayerDto)
    {
        PlayerDataResponseDTO? responseDto;

        if (addedPlayerDto.IsRandomGameMode)
        {
            
            // Search First Not Full Room In Repo
            var halfEmptyRoom = new RoomDto();

            if (halfEmptyRoom != null)
            {
                // Append Player To Room
                // Save Room In Repo
            }
            else
            {
                var newRoomHubId = $"TestRoom_{_random.Next(1000, 1999)}";
                var newRoom = new RoomDto
                {
                    HubGroupId = newRoomHubId,
                    RoomGuid = _hashService.CalculateHashCodeFrom(newRoomHubId)
                };

                // Add Room to Repo
            }
            responseDto = new PlayerDataResponseDTO { };
        }
        else
        {
            responseDto = null;
            Console.WriteLine("Method PlayerManager.AddNewPlayer() with flag (IsRandomGameMode = false) haven't realized yet!");
        }

        return responseDto;
    }

    public PlayerDataResponseDTO ChangePlayerNickName(string prevNickName, string newNickName)
    {
        if (string.IsNullOrEmpty(prevNickName) || string.IsNullOrEmpty(newNickName))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Player tried to add empty nick. Old - {prevNickName}, New - {newNickName} Nick didn't change!");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            return null;
        }

        // Calculate Player Hash Guid

        // Check Player In Repo
        var existedNewPlayer = new PlayerDataResponseDTO();

        if (existedNewPlayer != null)
        {
            // Update Player In Repo

            Console.WriteLine($"Поменяли никнейм новому игроку, старый: {prevNickName}, новый: {newNickName}, успешно нашли его под старым uuid: {Guid.Empty}, новый uuid: {Guid.Empty}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Игрок с ником {prevNickName} не найден на сервере!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        return new PlayerDataResponseDTO() { NickName = newNickName };
    }

    public List<PlayerDataResponseDTO> GetAllPlayersWithoutRoom()
    {
        return new List<PlayerDataResponseDTO>();
    }

    public PlayerDataResponseDTO RemovePlayer(string connectionId)
    {
        return new PlayerDataResponseDTO();
    }

    public PlayerDataResponseDTO MakePlayerReadyToGame(string connectionId)
    {
        Console.WriteLine("Method PlayerManager.MakePlayerReadyToGame() haven't realized yet!");
        return new PlayerDataResponseDTO();
    }

    public PlayerDataResponseDTO SetMatchTypeToPlayer(string connectionId, bool matchType)
    {
        Console.WriteLine("Method PlayerManager.SetMatchTypeToPlayer() haven't realized yet!");
        return new PlayerDataResponseDTO();
    }

}