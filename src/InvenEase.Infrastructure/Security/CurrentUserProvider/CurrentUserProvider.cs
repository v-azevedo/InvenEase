using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace InvenEase.Infrastructure.Security.CurrentUserProvider;

public class CurrentUserProvider(IHttpContextAccessor httpContextAccessor) : ICurrentUserProvider
{
    public CurrentUser Get()
    {
        if (httpContextAccessor.HttpContext is null)
        {
            throw new InvalidOperationException("HttpContext is null");
        }

        var id = Guid.Parse(GetSingleClaimValue(ClaimTypes.NameIdentifier));
        var permissions = GetClaimValues("permissions");
        var roles = GetClaimValues(ClaimTypes.Role);
        var firstName = GetSingleClaimValue(ClaimTypes.GivenName);
        var lastName = GetSingleClaimValue(ClaimTypes.Surname);
        var email = GetSingleClaimValue(ClaimTypes.Email);

        return new CurrentUser(id, firstName, lastName, email, permissions, roles);
    }

    private List<string> GetClaimValues(string claimType) =>
        httpContextAccessor.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();

    private string GetSingleClaimValue(string claimType) =>
        httpContextAccessor.HttpContext!.User.Claims
            .Single(claim => claim.Type == claimType)
            .Value;
}