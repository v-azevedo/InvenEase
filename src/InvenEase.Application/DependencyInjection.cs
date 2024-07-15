using InvenEase.Application.Services.Authentication.Commands;
using InvenEase.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace InvenEase.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();

        return services;
    }
}