using ErrorOr;

using InvenEase.Application.Common.Security.Request;

namespace InvenEase.Application.Common.Interfaces.Services;

public interface IAuthorizationService
{
    ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizeableRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions);
}