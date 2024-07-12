using FakeItEasy;
using FluentAssertions;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Application.Services.Authentication;
using InvenEase.Domain.Entities;


namespace InvenEase.Application.UnitTests.Services.Authentication;

public class AuthenticationServiceTests
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationServiceTests()
    {
        _jwtTokenGenerator = A.Fake<IJwtTokenGenerator>();
        _userRepository = A.Fake<IUserRepository>();
    }

    [Fact]
    public void AuthenticationService_Login_ReturnAuthenticationResult()
    {
        // Arrange
        var service = new AuthenticationService(_jwtTokenGenerator, _userRepository);
        var user = new User
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test.user@email.com",
            Password = "test@123"
        };
        A.CallTo(() => _userRepository.GetUserByEmail(user.Email)).Returns(user);

        // Act
        var result = service.Login(user.Email, user.Password);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
    }

    [Fact]
    public void AuthenticationService_Register_ReturnAuthenticationResult()
    {
        // Arrange
        var service = new AuthenticationService(_jwtTokenGenerator, _userRepository);
        var user = new User
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test.user@email.com",
            Password = "test@123"
        };
        A.CallTo(() => _userRepository.GetUserByEmail(user.Email)).Returns(null);

        // Act
        var result = service.Register(user.FirstName, user.LastName, user.Email, user.Password);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
    }

    [Fact]
    public void AuthenticationService_Login_ReturnCorrectUserByEmail()
    {
        // Arrange
        var service = new AuthenticationService(_jwtTokenGenerator, _userRepository);
        var user = new User
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test.user@email.com",
            Password = "test@123"
        };
        var expectedResult = new AuthenticationResult(
            user,
            "token");
        A.CallTo(() => _userRepository.GetUserByEmail(user.Email)).Returns(user);

        // Act
        var result = service.Login(user.Email, user.Password);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedResult, options => options.Excluding(er => er.Token));
    }

    [Fact]
    public void AuthenticationService_Login_ShouldThrowExceptionWhenInvalidParameters()
    {
        // Arrange
        var service = new AuthenticationService(_jwtTokenGenerator, _userRepository);
        A.CallTo(() => _userRepository.GetUserByEmail("test.user@email.com")).Returns(null);

        // Act
        Action act = () => service.Login("test.user@email.com", "test@123");

        // Assert
        act.Should().Throw<Exception>()
            .Where(e => e.Message.StartsWith("Invalid"));
    }
}