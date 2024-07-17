using ErrorOr;
using InvenEase.Application.Authentication.Common;
using MediatR;

namespace InvenEase.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;