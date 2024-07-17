using InvenEase.Domain.Entities;

namespace InvenEase.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);