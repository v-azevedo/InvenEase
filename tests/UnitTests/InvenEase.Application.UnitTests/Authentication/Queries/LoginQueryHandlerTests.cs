using FakeItEasy;
using FluentAssertions;
using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Authentication.Queries.Login;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.Entities;

namespace InvenEase.Application.UnitTests.Authentication.Queries;

public class LoginQueryHandlerTests
{
    private readonly IUserRepository _userRepository = A.Fake<IUserRepository>();
    private readonly IJwtTokenGenerator _jwtTokenGenerator = A.Fake<IJwtTokenGenerator>();

    [Fact]
    public void HandleLoginQuery_WhenValidCredentials_ReturnAuthenticationResult()
    {
        // Arrange
        var handler = new LoginQueryHandler(_userRepository, _jwtTokenGenerator);
        var query = A.Dummy<LoginQuery>();

        A.CallTo(() => _userRepository.GetUserByEmail(query.Email)).Returns(A.Dummy<User>());

        // Act
        var result = handler.Handle(query, CancellationToken.None).Result.Value;

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<AuthenticationResult>();
    }

    [Fact]
    public void HandleLoginQuery_WhenInvalidCredentials_ReturnError()
    {
        // Arrange
        var handler = new LoginQueryHandler(_userRepository, _jwtTokenGenerator);
        var query = A.Dummy<LoginQuery>();

        A.CallTo(() => _userRepository.GetUserByEmail(query.Email)).Returns(null);

        // Act
        var result = handler.Handle(query, CancellationToken.None).Result;

        // Assert
        result.Value.Should().BeNull();
        result.FirstError.Should().NotBeNull();
        result.FirstError.Should().Be(Errors.Authentication.InvalidCredentials);
    }

    private class DummyUserFactory : DummyFactory<User>
    {
        protected override User Create()
        {
            return new User
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Password = ""
            };
        }
    }
}