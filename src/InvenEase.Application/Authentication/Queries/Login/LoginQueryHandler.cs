using ErrorOr;

using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.UserAggregate;

using MediatR;

namespace InvenEase.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IUsersRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator,
    IPasswordHasher passwordHasher)
        : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await userRepository.GetUserByEmailAsync(query.Email, cancellationToken) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!passwordHasher.Verify(query.Password, user.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}