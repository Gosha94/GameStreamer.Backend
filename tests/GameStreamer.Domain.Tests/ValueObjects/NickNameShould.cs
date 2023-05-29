using FluentAssertions;
using GameStreamer.Domain.Errors;
using GameStreamer.Domain.ValueObjects;

namespace GameStreamer.Domain.Tests.ValueObjects;

public class NickNameShould
{
    [Fact]
    public void ReturnsFailure_WhenNickNameIsEmpty()
    {
        // Arrange

        // Act
        var actualResult = NickName.Create(string.Empty);

        // Assert
        actualResult.Error.Should().Be(DomainErrors.EmptyNickName);
    }

    [Fact]
    public void ReturnsFailure_WhenNickNameIsTooLong()
    {
        // Arrange

        // Act
        var actualResult = NickName.Create("TooLongNickNameEverEverCreatedForTest");

        // Assert
        actualResult.Error.Should().Be(DomainErrors.TooLongNickName);
    }

}