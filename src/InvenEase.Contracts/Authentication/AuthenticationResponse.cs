namespace InvenEase.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    List<string> Roles,
    List<string> Permissions,
    string Token);