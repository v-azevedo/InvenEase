using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Domain.Common;

namespace InvenEase.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            Role.Requester,
            "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName, Role.Requester);

        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            Role.Requester,
            token);
    }
}