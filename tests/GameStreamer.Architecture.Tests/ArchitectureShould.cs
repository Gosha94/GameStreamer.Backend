using Xunit;
using NetArchTest.Rules;

namespace GameStreamer.Architecture.Tests;

public class ArchitectureShould
{

    private const string DomainNamespace = "GameStreamer.Domain";
    private const string ApplicationNamespace = "GameStreamer.Application";
    private const string InfrastructureNamespace = "GameStreamer.Infrastructure";
    private const string PresentationNamespace = "GameStreamer.Presentation";
    private const string WebUINamespace = "GameStreamer.UI";

    [Fact]
    public void DomainLayer_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var domainAssembly = typeof(Domain.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace,
                WebUINamespace
            };

        // Act
        var expectedResult = Types
            .InAssembly(domainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        Assert.True(expectedResult.IsSuccessful);
    }

    [Fact]
    public void ApplicationLayer_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
                InfrastructureNamespace,
                PresentationNamespace,
                WebUINamespace
            };

        // Act
        var expectedResult = Types
            .InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        Assert.True(expectedResult.IsSuccessful);
    }

    [Fact]
    public void InfrastructureLayer_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var infrastructureAssembly = typeof(Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
                PresentationNamespace,
                WebUINamespace
            };

        // Act
        var expectedResult = Types
            .InAssembly(infrastructureAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        Assert.True(expectedResult.IsSuccessful);
    }

    [Fact]
    public void PresentationLayer_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
                InfrastructureNamespace,
                WebUINamespace
            };

        // Act
        var expectedResult = Types
            .InAssembly(presentationAssembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        Assert.True(expectedResult.IsSuccessful);
    }

    [Fact]
    public void Handlers_Should_HaveDependencyOnDomainLayer()
    {
        // Arrange
        var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

        // Act
        var expectedResult = Types
            .InAssembly(applicationAssembly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        Assert.True(expectedResult.IsSuccessful);
    }

    [Fact]
    public void Controllers_Should_HaveDependencyOnMediatR()
    {
        // Arrange
        var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

        // Act
        var expectedResult = Types
            .InAssembly(presentationAssembly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn("MediatR")
            .GetResult();

        // Assert
        Assert.True(expectedResult.IsSuccessful);
    }

}