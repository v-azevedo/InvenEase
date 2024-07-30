using System.Text;

using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Application.Common.Interfaces.Services;
using InvenEase.Infrastructure.Items.Repository;
using InvenEase.Infrastructure.Persistence;
using InvenEase.Infrastructure.Security;
using InvenEase.Infrastructure.Security.CurrentUserProvider;
using InvenEase.Infrastructure.Security.HashGenerator;
using InvenEase.Infrastructure.Security.TokenGenerator;
using InvenEase.Infrastructure.Services;
using InvenEase.Infrastructure.Users.Repository;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace InvenEase.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddServices()
            .AddAuthentication(configuration)
            .AddAuthorization()
            .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services, IConfiguration configuration)
    {
        var postgresSettings = new PostgresSettings();
        configuration.Bind(PostgresSettings.SectionName, postgresSettings);

        services.AddSingleton(Options.Create(postgresSettings));
        services.AddDbContext<InvenEaseDbContext>(options =>
            options.UseNpgsql(postgresSettings.ConnectionString));

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }

    private static IServiceCollection AddAuthentication(
        this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

        return services;
    }
}