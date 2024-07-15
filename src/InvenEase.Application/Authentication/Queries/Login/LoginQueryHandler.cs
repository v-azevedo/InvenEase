using ErrorOr;
using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.Entities;
using MediatR;

namespace InvenEase.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email) is not User user || user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}