using System.Reflection;

using ErrorOr;

using InvenEase.Application.Common.Interfaces.Services;
using InvenEase.Application.Common.Security.Request;
using InvenEase.Infrastructure.Security.Request;

using MediatR;

namespace InvenEase.Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse>(IAuthorizationService authorizationService)
    : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IAuthorizeableRequest<TResponse>
        where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizationAttributes = request.GetType()
            .GetCustomAttributes<AuthorizeAttribute>()
            .ToList();

        if (authorizationAttributes.Count == 0)
        {
            return await next();
        }

        var requiredPermissions = authorizationAttributes
            .SelectMany(authorizationAttribute => authorizationAttribute.Permissions?.Split(',') ?? [])
            .ToList();

        var requiredRoles = authorizationAttributes
            .SelectMany(authorizationAttribute => authorizationAttribute.Roles?.Split(',') ?? [])
            .ToList();

        var authorizationResult = authorizationService.AuthorizeCurrentUser(
            request,
            requiredRoles,
            requiredPermissions);

        return authorizationResult.IsError
            ? (dynamic)authorizationResult.Errors
            : await next();
    }
}