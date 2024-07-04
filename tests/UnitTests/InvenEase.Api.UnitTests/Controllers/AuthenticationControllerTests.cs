using FakeItEasy;
using InvenEase.Api.Controllers;
using InvenEase.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.UnitTests.Controllers;

public class AuthenticationControllerTests
{
    [Fact]
    public void AuthenticationController_Register_ReturnAuthenticationResult()
    {
        // Arrange
        var controller = new AuthenticationController();
        var request = A.Fake<RegisterRequest>();

        // Act
        var result = controller.Register(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void AuthenticationController_Login_ReturnAuthenticationResult()
    {
        // Arrange
        var controller = new AuthenticationController();
        var request = A.Fake<LoginRequest>();

        // Act
        var result = controller.Login(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}