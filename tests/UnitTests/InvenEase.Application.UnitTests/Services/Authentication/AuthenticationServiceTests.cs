using FakeItEasy;
using FluentAssertions;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Services.Authentication;
using InvenEase.Domain.Common;

namespace InvenEase.Application.UnitTests.Services.Authentication;

public class AuthenticationServiceTests
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationServiceTests()
    {
        _jwtTokenGenerator = A.Fake<IJwtTokenGenerator>();
    }

    [Fact]
    public void AuthenticationService_Login_ReturnAuthenticationResult()
    {
        // Arrange
        var service = new AuthenticationService(_jwtTokenGenerator);

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
        var service = new AuthenticationService(_jwtTokenGenerator);
        var userId = Guid.NewGuid();
        var password = "password";
        var expected = new AuthenticationResult(
            userId,
            "john",
            "doe",
            "john.doe@email.com",
            Role.Requester,
            "token");

        // Act
        var result = service.Register(expected.FirstName, expected.LastName, expected.Email, password);

        // Assert
        result.Should().BeOfType<AuthenticationResult>();
        result.Should().BeEquivalentTo(expected, options =>
            options
                .Excluding(o => o.Id)
                .Excluding(o => o.Token)
        );
        result.Id.Should().NotBeEmpty();
    }
}