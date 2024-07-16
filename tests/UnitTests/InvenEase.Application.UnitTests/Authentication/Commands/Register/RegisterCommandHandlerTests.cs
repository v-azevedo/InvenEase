using FakeItEasy;
using FluentAssertions;
using InvenEase.Application.Authentication.Commands.Register;
using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.Entities;

namespace InvenEase.Application.UnitTests.Authentication.Commands.Register;

public class RegisterCommandHandlerTests
{
    private readonly IUserRepository _userRepository = A.Fake<IUserRepository>();
    private readonly IJwtTokenGenerator _jwtTokenGenerator = A.Fake<IJwtTokenGenerator>();

    [Fact]
    public void HandleRegisterCommand_WhenValidCredentials_ReturnAuthenticationResult()
    {
        // Arrange
        var handler = new RegisterCommandHandler(_userRepository, _jwtTokenGenerator);
        var command = A.Dummy<RegisterCommand>();

        A.CallTo(() => _userRepository.GetUserByEmail(command.Email)).Returns(null);

        // Act
        var result = handler.Handle(command, CancellationToken.None).Result.Value;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
    }

    [Fact]
    public void HandleRegisterCommand_WhenDuplicateEmail_ReturnError()
    {
        // Arrange
        var handler = new RegisterCommandHandler(_userRepository, _jwtTokenGenerator);
        var command = A.Dummy<RegisterCommand>();

        A.CallTo(() => _userRepository.GetUserByEmail(command.Email)).Returns(A.Dummy<User>());

        // Act
        var result = handler.Handle(command, CancellationToken.None).Result;

        // Assert
        result.Value.Should().BeNull();
        result.FirstError.Should().NotBeNull();
        result.FirstError.Should().Be(Errors.User.DuplicateEmail);
    }
}