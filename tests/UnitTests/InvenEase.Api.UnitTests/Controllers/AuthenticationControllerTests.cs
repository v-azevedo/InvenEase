using FakeItEasy;
using FluentAssertions;
using InvenEase.Api.Controllers;
using InvenEase.Application.Authentication.Commands.Register;
using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Authentication.Queries.Login;
using InvenEase.Contracts.Authentication;
using InvenEase.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.UnitTests.Controllers;

public class AuthenticationControllerTests
{
    private readonly ISender _mediator;
    private readonly AuthenticationController _controller;

    public AuthenticationControllerTests()
    {
        _mediator = A.Fake<ISender>();

        // SUT
        _controller = new AuthenticationController(_mediator);
    }

    [Fact]
    public async Task AuthenticationController_Register_ReturnOk()
    {
        // Arrange
        var request = A.Fake<RegisterRequest>();
        A.CallTo(() => _mediator.Send(A<RegisterCommand>._, default))
            .Returns(new AuthenticationResult(new User { }, Token: ""));

        // Act
        var result = await _controller.Register(request);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task AuthenticationController_Login_ReturnOK()
    {
        // Arrange
        var request = A.Fake<LoginRequest>();
        A.CallTo(() => _mediator.Send(A<LoginQuery>._, default))
            .Returns(new AuthenticationResult(new User { }, Token: ""));

        // Act
        var result = await _controller.Login(request);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }
}