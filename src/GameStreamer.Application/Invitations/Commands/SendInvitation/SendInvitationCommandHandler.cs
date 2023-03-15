using GameStreamer.Domain.Entities;
using MediatR;
using GameStreamer.Domain.Repositories;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Invitations.Commands.SendInvitation;

internal sealed class SendInvitationCommandHandler : IRequestHandler<SendInvitationCommand, Unit>
{

    private readonly IRoomRepository _roomRepository;
    private readonly IIncomerRepository _incomerRepository;
    private readonly IInvitationRepository _invitationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public SendInvitationCommandHandler(
        IRoomRepository roomRepository,
        IIncomerRepository incomerRepository,
        IInvitationRepository invitationRepository,
        IUnitOfWork unitOfWork,
        IEmailService emailService)
    {
        _roomRepository = roomRepository;
        _incomerRepository = incomerRepository;
        _invitationRepository = invitationRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<Unit> Handle(SendInvitationCommand request, CancellationToken cancellationToken)
    {
        var incomer = await _incomerRepository.GetByIdAsync(request.IncomerId, cancellationToken);
        var room = await _roomRepository
            .GetByIdWithCreatorAsync(request.RoomId, cancellationToken);

        if (incomer is null || room is null)
        {
            return Unit.Value;
        }

        Result<Invitation> invitationResult = room.SendInvitation(incomer);

        if (invitationResult.IsFailure)
        {
            // Log Error

            return Unit.Value;
        }

        _invitationRepository.Add(invitationResult.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _emailService.SendInvitationSentEmailAsync(incomer, room, cancellationToken);

        return Unit.Value;
    }
}