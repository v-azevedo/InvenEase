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
    public void AuthenticationController_Register_ReturnOk()

    {
        // Arrange
        var controller = new AuthenticationController(_authenticationService);
        var request = A.Fake<RegisterRequest>();

        // Act
        var result = controller.Register(request);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public void AuthenticationController_Login_ReturnOK()

    {
        // Arrange
        var controller = new AuthenticationController(_authenticationService);
        var request = A.Fake<LoginRequest>();

        // Act
        var result = controller.Login(request);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
}