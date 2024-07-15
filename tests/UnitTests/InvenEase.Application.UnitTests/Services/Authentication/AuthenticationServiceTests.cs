using FakeItEasy;
using FluentAssertions;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Application.Services.Authentication;
using InvenEase.Application.Services.Authentication.Commands;
using InvenEase.Application.Services.Authentication.Common;
using InvenEase.Application.Services.Authentication.Queries;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.Entities;

namespace InvenEase.Application.UnitTests.Services.Authentication;

public class AuthenticationServiceTests
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly User user = new()
    {
        FirstName = "Test",
        LastName = "User",
        Email = "test.user@email.com",
        Password = "test@123"
    };

    public AuthenticationServiceTests()
    {
        _jwtTokenGenerator = A.Fake<IJwtTokenGenerator>();
        _userRepository = A.Fake<IUserRepository>();
    }

    [Fact]
    public void AuthenticationService_Login_ReturnAuthenticationResult()
    {
        // Arrange
        var service = new AuthenticationQueryService(_jwtTokenGenerator, _userRepository);

        A.CallTo(() => _userRepository.GetUserByEmail(user.Email)).Returns(user);

        // Act
        var result = service.Login(user.Email, user.Password).Value;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
    }

    [Fact]
    public void AuthenticationService_Register_ReturnAuthenticationResult()
    {
        // Arrange
        var service = new AuthenticationCommandService(_jwtTokenGenerator, _userRepository);

        A.CallTo(() => _userRepository.GetUserByEmail(user.Email)).Returns(null);

        // Act
        var result = service.Register(user.FirstName, user.LastName, user.Email, user.Password).Value;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
    }

    [Fact]
    public void AuthenticationService_Login_ReturnCorrectUserByEmail()
    {
        // Arrange
        var service = new AuthenticationQueryService(_jwtTokenGenerator, _userRepository);

        var expectedResult = new AuthenticationResult(
            user,
            "token");
        A.CallTo(() => _userRepository.GetUserByEmail(user.Email)).Returns(user);

        // Act
        var result = service.Login(user.Email, user.Password).Value;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedResult, options => options.Excluding(er => er.Token));
    }

    [Fact]
    public void AuthenticationService_Login_ShouldBeErrorWhenInvalidCredentials()
    {
        // Arrange
        var service = new AuthenticationQueryService(_jwtTokenGenerator, _userRepository);
        A.CallTo(() => _userRepository.GetUserByEmail("test.user@email.com")).Returns(null);

        // Act
        var authResult = service.Login("test.user@email.com", "test@123");

        // Assert
        authResult.IsError.Should().BeTrue();
        authResult.FirstError.Should().Be(Errors.Authentication.InvalidCredentials);
    }

    [Fact]
    public void AuthenticationService_Register_ShouldBeErrorWhenDuplicateEmail()
    {
        // Arrange
        var service = new AuthenticationCommandService(_jwtTokenGenerator, _userRepository);
        A.CallTo(() => _userRepository.GetUserByEmail(user.Email)).Returns(user);

        // Act
        var authResult = service.Register(user.FirstName, user.LastName, user.Email, user.Password);

        // Assert
        authResult.IsError.Should().BeTrue();
        authResult.FirstError.Should().Be(Errors.User.DuplicateEmail);
    }
}