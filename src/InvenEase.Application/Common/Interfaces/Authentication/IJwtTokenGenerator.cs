using InvenEase.Domain.Common;

namespace InvenEase.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName, Role role);
}