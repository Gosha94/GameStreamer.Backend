using GameStreamer.Application.Abstractions.Messaging;
using GameStreamer.Domain.Entities;
using GameStreamer.Domain.Repositories;
using GameStreamer.Domain.Services;
using GameStreamer.Domain.Shared;

namespace GameStreamer.Application.Invitations.Commands.SendInvitation;

internal sealed class SendInvitationCommandHandler : ICommandHandler<SendInvitationCommand, Result>
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

    public async Task<Result> Handle(SendInvitationCommand request, CancellationToken cancellationToken)
    {
        var incomer = await _incomerRepository.GetByIdAsync(request.IncomerId, cancellationToken);
        var room = await _roomRepository
            .GetByIdWithCreatorAsync(request.RoomId, cancellationToken);

        if (incomer is null || room is null)
        {
            return Result.Failure(Error.NullValue);
        }

        Result<Invitation> invitationResult = room.SendInvitation(incomer);

        if (invitationResult.IsFailure)
        {
            // Log Error

            return Result.Failure<Invitation>(invitationResult.Error);
        }

        _invitationRepository.Add(invitationResult.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _emailService.SendInvitationSentEmailAsync(incomer, room, cancellationToken);

        return Result.Success(invitationResult.IsSuccess);
    }
}