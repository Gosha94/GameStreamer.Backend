﻿using GameStreamer.Domain.Shared;
using GameStreamer.Domain.Entities;
using GameStreamer.Domain.ValueObjects;
using GameStreamer.Domain.Repositories;
using GameStreamer.Application.Abstractions.Messaging;

namespace GameStreamer.Application.Incomers.Commands.CreateIncomer;

internal sealed class CreateIncomerCommandHandler : ICommandHandler<CreateIncomerCommand, Result>
{

    private readonly IIncomerRepository _incomerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateIncomerCommandHandler(
        IIncomerRepository incomerRepository,
        IUnitOfWork unitOfWork)
    {
        _incomerRepository = incomerRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Result> Handle(CreateIncomerCommand request, CancellationToken cancellationToken)
    {
        Result<NickName> nickNameResult = NickName.Create(request.NickName);

        if (nickNameResult.IsFailure)
        {
            // Log Error

            return Result.Failure(nickNameResult.Error);
        }

        var incomer = Incomer.Create(
            nickNameResult.Value);

        _incomerRepository.Add(incomer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}