using ErrorOr;
using InvenEase.Application.Services.Authentication.Common;

namespace InvenEase.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}