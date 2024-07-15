using ErrorOr;
using InvenEase.Application.Services.Authentication.Common;

namespace InvenEase.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}