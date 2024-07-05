using InvenEase.Domain.Common;

namespace InvenEase.Application.Services.Authentication;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    Role Role,
    string Token
);