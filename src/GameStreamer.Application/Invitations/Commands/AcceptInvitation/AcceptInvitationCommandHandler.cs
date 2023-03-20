using GameStreamer.Domain.Entities.Rooms;
using GameStreamer.Domain.Enums;
using GameStreamer.Domain.Repositories;
using GameStreamer.Domain.Shared;
using MediatR;

namespace GameStreamer.Application.Invitations.Commands.AcceptInvitation;

internal sealed class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand, Unit>
{

    private readonly IInvitationRepository _invitationRepository;
    private readonly IIncomerRepository _incomerRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomieRepository _roomieRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public AcceptInvitationCommandHandler(
        IInvitationRepository invitationRepository,
        IIncomerRepository incomerRepository,
        IRoomRepository roomRepository,
        IRoomieRepository roomieRepository,
        IUnitOfWork unitOfWork,
        IEmailService emailService)
    {
        _invitationRepository = invitationRepository;
        _incomerRepository = incomerRepository;
        _roomRepository = roomRepository;
        _roomieRepository = roomieRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<Unit> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository
            .GetByIdWithCreatorAsync(request.RoomId, cancellationToken);

        if (room is null)
        {
            return Unit.Value;
        }

        var invitation = room.Invitations
            .FirstOrDefault(i => i.Id == request.InvitationId);

        if (invitation is null || invitation.Status != InvitationStatus.Pending)
        {
            return Unit.Value;
        }

        Result<Roomie> roomieResult = room.AcceptInvitation(invitation);

        if (roomieResult.IsSuccess)
        {
            _roomieRepository.Add(roomieResult.Value);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        if (invitation.Status == InvitationStatus.Accepted)
        {
            await _emailService.SendInvitationAcceptedEmailAsync(room.Creator.Id);
        }

        return Unit.Value;
    }
}