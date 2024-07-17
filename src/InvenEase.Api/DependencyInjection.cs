using InvenEase.Api.Common.Errors;
using InvenEase.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace InvenEase.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, InvenEaseProblemDetailsFactory>();

        services.AddMapping();

        return services;
    }
}