using FakeItEasy;
using FluentAssertions;
using InvenEase.Api.Controllers;
using InvenEase.Application.Services.Authentication.Commands;
using InvenEase.Application.Services.Authentication.Common;
using InvenEase.Application.Services.Authentication.Queries;
using InvenEase.Contracts.Authentication;
using InvenEase.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.UnitTests.Controllers;

public class AuthenticationControllerTests
{
    private readonly IAuthenticationQueryService _authenticationQueryService;
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly AuthenticationController _controller;

    public AuthenticationControllerTests()
    {
        _authenticationQueryService = A.Fake<IAuthenticationQueryService>();
        _authenticationCommandService = A.Fake<IAuthenticationCommandService>();

        // SUT
        _controller = new AuthenticationController(_authenticationQueryService, _authenticationCommandService);
    }

    [Fact]
    public void AuthenticationController_Register_ReturnOk()
    {
        // Arrange
        var request = A.Fake<RegisterRequest>();
        A.CallTo(() => _authenticationCommandService
            .Register(request.FirstName, request.LastName, request.Email, request.Password))
                .Returns(new AuthenticationResult(new User { }, Token: ""));

        // Act
        var result = _controller.Register(request);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public void AuthenticationController_Login_ReturnOK()
    {
        // Arrange
        var request = A.Fake<LoginRequest>();
        A.CallTo(() => _authenticationQueryService
            .Login(request.Email, request.Password))
                .Returns(new AuthenticationResult(new User { }, Token: ""));

        // Act
        var result = _controller.Login(request);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
}