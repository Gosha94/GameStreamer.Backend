using MediatR;
using GameStreamer.Domain.Repositories;
using GameStreamer.Domain.Entities;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Rooms.Commands.CreateRoom;

internal sealed class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Result>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoomRepository _roomRepository;
    private readonly IIncomerRepository _incomerRepository;

    public CreateRoomCommandHandler(
        IUnitOfWork unitOfWork,
        IRoomRepository roomRepository,
        IIncomerRepository incomerRepository)
    {
        _unitOfWork = unitOfWork;
        _roomRepository = roomRepository;
        _incomerRepository = incomerRepository;
    }

    public async Task<Result> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {

        var incomer = await _incomerRepository.GetByIdAsync(request.IncomerId, cancellationToken);
        
        if (incomer is null)
        {
            return Result.Failure(new Error("IncomerRepository.GetByIdAsync", $"Incomer doesn't exist by Id: {request.IncomerId}."));
        }

        var room = Room.Create(Guid.NewGuid(), incomer, request.RoomName);

        if (request.MaximumNumberOfRoomies is null)
        {
            throw new Exception(
                $"{nameof(request.MaximumNumberOfRoomies)} can't be null.");
        }

        _roomRepository.Add(room);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}