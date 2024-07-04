using FluentAssertions;
using InvenEase.Application.Services.Authentication;

namespace InvenEase.Application.UnitTests.Services.Authentication;

public class AuthenticationServiceTests
{
    [Fact]
    public void AuthenticationService_Login_ReturnAuthenticationResult()
    {
        // Arrange
        var service = new AuthenticationService();

        // Act
        var result = service.Login("test@email.com", "password");

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
    }

    [Fact]
    public void AuthenticationService_Register_ReturnAuthenticationResult()
    {
        // Arrange
        var service = new AuthenticationService();
        var expected = new AuthenticationResult(
            Guid.NewGuid(),
            "john",
            "doe",
            "john.doe@email.com",
            "requester",
            "token");

        // Act
        var result = service.Register("john", "doe", "john.doe@email.com", "password");

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
        result.Should().BeEquivalentTo(expected, options =>
            options.Excluding(o => o.Id)
        );
    }
}