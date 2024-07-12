using InvenEase.Domain.Entities;

namespace InvenEase.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}