using System.Text;

using InvenEase.Application.Common.Interfaces.Authentication;
using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Application.Common.Interfaces.Services;
using InvenEase.Infrastructure.Authentication;
using InvenEase.Infrastructure.Persistence;
using InvenEase.Infrastructure.Persistence.Repositories;
using InvenEase.Infrastructure.Services;

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
            .AddAuth(configuration)
            .AddPersistence(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services, IConfiguration configuration)
    {
        var postgresSettings = new PostgresSettings();
        configuration.Bind(PostgresSettings.SectionName, postgresSettings);

        services.AddSingleton(Options.Create(postgresSettings));
        services.AddDbContext<InvenEaseDbContext>(options =>
            options.UseNpgsql(postgresSettings.ConnectionString));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

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
}