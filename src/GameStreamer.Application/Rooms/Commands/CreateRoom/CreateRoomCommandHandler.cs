using GameStreamer.Domain.Entities;
using MediatR;
using GameStreamer.Domain.Repositories;

namespace GameStreamer.Application.Rooms.Commands.CreateRoom;

internal sealed class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Unit>
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

    public async Task<Unit> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {

        var incomer = await _incomerRepository.GetByIdAsync(request.IncomerId, cancellationToken);
        
        if (incomer is null)
        {
                return Unit.Value;
        }

        var room = Room.Create(Guid.NewGuid(), incomer, request.RoomName);

        if (request.MaximumNumberOfRoomies is null)
        {
            throw new Exception(
                $"{nameof(request.MaximumNumberOfRoomies)} can't be null.");
        }

        _roomRepository.Add(room);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}