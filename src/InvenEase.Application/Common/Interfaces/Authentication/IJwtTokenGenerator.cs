using InvenEase.Domain.UserAggregate;

namespace InvenEase.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}