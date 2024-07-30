using ErrorOr;

using InvenEase.Application.Authentication.Common;
using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Application.Common.Security.Roles;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.UserAggregate;
using InvenEase.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace InvenEase.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IUsersRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator,
    IPasswordHasher passwordHasher)
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await userRepository.GetUserByEmailAsync(command.Email, cancellationToken) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.Create(
            firstName: command.FirstName,
            lastName: command.LastName,
            email: command.Email,
            password: passwordHasher.Hash(command.Password));

        await userRepository.AddAsync(user, cancellationToken);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}