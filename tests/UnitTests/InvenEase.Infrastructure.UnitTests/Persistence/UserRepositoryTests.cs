using FakeItEasy;

using FluentAssertions;

using InvenEase.Domain.Entities;
using InvenEase.Infrastructure.Persistence.Repositories;

namespace InvenEase.Infrastructure.UnitTests.Persistence;

public class UserRepositoryTests
{
    private readonly UserRepository _userRepository;

    public UserRepositoryTests()
    {
        // SUT
        _userRepository = new UserRepository();
    }

    [Fact]
    public void GetUserByEmail_WhenFound_ShouldReturnUser()
    {
        // Arrange
        var user = A.Fake<User>();
        _userRepository.Add(user);

        // Act
        var result = _userRepository.GetUserByEmail(user.Email);

        // Assert
        result.Should().BeEquivalentTo(user);
    }
}