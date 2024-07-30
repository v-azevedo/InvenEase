using ErrorOr;

using InvenEase.Application.Common.Interfaces.Services;
using InvenEase.Application.Common.Security.Request;
using InvenEase.Infrastructure.Security.CurrentUserProvider;

namespace InvenEase.Infrastructure.Security;

public class AuthorizationService(
    ICurrentUserProvider currentUserProvider)
        : IAuthorizationService
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "<Improved Readability>")]
    public ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizeableRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions)
    {
        var currentUser = currentUserProvider.Get();

        if (requiredPermissions.Except(currentUser.Permissions).Any())
        {
            return Error.Unauthorized(description: "User is missing required permissions for taking this action");
        }

        if (requiredRoles.Except(currentUser.Roles).Any())
        {
            return Error.Unauthorized(description: "User is missing required roles for taking this action");
        }

        return Result.Success;
    }
}