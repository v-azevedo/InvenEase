using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.UserAggregate;
using InvenEase.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace InvenEase.Infrastructure.Users.Repository;

public class UsersRepository(InvenEaseDbContext dbContext) : IUsersRepository
{
    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.Users.FindAsync([userId], cancellationToken: cancellationToken);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task RemoveAsync(User user, CancellationToken cancellationToken)
    {
        dbContext.Remove(user);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        dbContext.Update(user);
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}