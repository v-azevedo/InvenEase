using InvenEase.Domain.UserAggregate;

namespace InvenEase.Application.Common.Interfaces.Persistence;

public interface IUsersRepository
{
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    Task RemoveAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
}