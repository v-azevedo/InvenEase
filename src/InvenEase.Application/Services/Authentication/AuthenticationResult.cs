using InvenEase.Domain.Entities;

namespace InvenEase.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);