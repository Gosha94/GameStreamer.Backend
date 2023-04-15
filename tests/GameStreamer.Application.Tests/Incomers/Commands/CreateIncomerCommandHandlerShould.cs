using AutoFixture.Xunit2;
using FluentAssertions;
using GameStreamer.Application.Incomers.Commands.CreateIncomer;
using GameStreamer.Application.Tests.Configuration;
using GameStreamer.Domain.Errors;
using GameStreamer.Domain.Repositories;
using GameStreamer.Domain.Shared;
using Moq;
using Xunit;

namespace GameStreamer.Application.Tests.Incomers.Commands
{
    public class CreateIncomerCommandHandlerShould
    {

        //private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        //private readonly Mock<IIncomerRepository> _incomerRepositoryMock;

        //public CreateIncomerCommandHandlerShould()
        //{
        //    _unitOfWorkMock = new();
        //    _incomerRepositoryMock = new();
        //}

        [Theory]
        [AutoMoqData]
        public async Task Handler_Should_ReturnsFailureResult_WhenIncomersNickNameEmpty(
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IIncomerRepository> incomerRepositoryMock
            )
        {
            // Arrange
            var command = new CreateIncomerCommand(string.Empty);

            var handlerUnderTest = new CreateIncomerCommandHandler(
                incomerRepositoryMock.Object,
                unitOfWorkMock.Object);

            // Act
            Result result = await handlerUnderTest.Handle(command, default);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(DomainErrors.EmptyNickName);
        }
    }
}
