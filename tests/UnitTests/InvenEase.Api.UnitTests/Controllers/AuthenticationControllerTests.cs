using FakeItEasy;
using FluentAssertions;
using InvenEase.Api.Controllers;
using InvenEase.Application.Services.Authentication;
using InvenEase.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.UnitTests.Controllers;

public class AuthenticationControllerTests
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationControllerTests()
    {
        _authenticationService = A.Fake<IAuthenticationService>();
    }

    [Fact]
    public void AuthenticationController_Register_ReturnAuthenticationResult()
    {
        // Arrange
        var controller = new AuthenticationController(_authenticationService);
        var request = A.Fake<RegisterRequest>();

        // Act
        var result = controller.Register(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void AuthenticationController_Register_ReturnAuthenticationResultWithCorrectValues()
    {
        // Arrange
        var controller = new AuthenticationController(_authenticationService);
        var request = new RegisterRequest(
            "firstName",
            "lastName",
            "email",
            "password"
        );
        var authResult = new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            "email",
            "requester",
            "token"
        );

        A.CallTo(() => _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        )).Returns(authResult);

        // Act
        var result = controller.Register(request) as OkObjectResult;
        var response = result!.Value as AuthenticationResponse;

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEquivalentTo(authResult, options => options.Excluding(o => o.Id));
    }

    [Fact]
    public void AuthenticationController_Login_ReturnAuthenticationResult()
    {
        // Arrange
        var controller = new AuthenticationController(_authenticationService);
        var request = A.Fake<LoginRequest>();

        // Act
        var result = controller.Login(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void AuthenticationController_Login_ReturnAuthenticationResultWithCorrectValues()
    {
        // Arrange
        var controller = new AuthenticationController(_authenticationService);
        var request = new LoginRequest(
            "email",
            "password"
        );
        var authResult = new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            "email",
            "requester",
            "token"
        );

        A.CallTo(() => _authenticationService.Login(
            request.Email,
            request.Password
        )).Returns(authResult);

        // Act
        var result = controller.Login(request) as OkObjectResult;
        var response = result!.Value as AuthenticationResponse;

        // Assert
        response.Should().NotBeNull();
        response.Should().BeEquivalentTo(authResult, options => options.Excluding(o => o.Id));
    }
}