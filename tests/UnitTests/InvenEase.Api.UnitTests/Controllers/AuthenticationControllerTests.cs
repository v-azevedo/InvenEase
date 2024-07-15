using FakeItEasy;
using FluentAssertions;
using InvenEase.Api.Controllers;
using InvenEase.Application.Services.Authentication;
using InvenEase.Contracts.Authentication;
using InvenEase.Domain.Entities;
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
        A.CallTo(() => _authenticationService
            .Register(request.FirstName, request.LastName, request.Email, request.Password))
                .Returns(new AuthenticationResult(new User { }, Token: ""));

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
        A.CallTo(() => _authenticationService
            .Login(request.Email, request.Password))
                .Returns(new AuthenticationResult(new User { }, Token: ""));

        // Act
        var result = controller.Login(request);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
}