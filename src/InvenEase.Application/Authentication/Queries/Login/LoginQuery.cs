using ErrorOr;
using InvenEase.Application.Authentication.Common;
using MediatR;

namespace InvenEase.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;