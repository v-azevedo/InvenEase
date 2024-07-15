using InvenEase.Domain.Entities;

namespace InvenEase.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);