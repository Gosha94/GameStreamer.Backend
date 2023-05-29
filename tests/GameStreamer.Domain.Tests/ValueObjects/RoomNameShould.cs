using FluentAssertions;
using GameStreamer.Domain.Errors;
using GameStreamer.Domain.ValueObjects;

namespace GameStreamer.Domain.Tests.ValueObjects;

public class RoomNameShould
{
    [Fact]
    public void ReturnsFailure_WhenRoomNameIsEmpty()
    {
        // Arrange

        // Act
        var actualResult = RoomName.Create(string.Empty);

        // Assert
        actualResult.Error.Should().Be(DomainErrors.EmptyRoomName);
    }

    [Fact]
    public void ReturnsFailure_WhenRoomNameIsTooLong()
    {
        // Arrange

        // Act
        var actualResult = RoomName.Create("TooLongRoomNameEverEverCreatedForTest");

        // Assert
        actualResult.Error.Should().Be(DomainErrors.TooLongRoomName);
    }
}
