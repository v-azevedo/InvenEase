using ErrorOr;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Application.Services.Authentication.Common;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.Entities;


namespace InvenEase.Application.Services.Authentication.Queries;

public class AuthenticationQueryService(
    IJwtTokenGenerator jwtTokenGenerator,
    IUserRepository userRepository) : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user || user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}