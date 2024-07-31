using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.RequestAggregate;
using InvenEase.Infrastructure.Persistence;

namespace InvenEase.Infrastructure.Requests.Repository;

public class RequestsRepository(InvenEaseDbContext dbContext) : IRequestRepository
{
    public async Task CreateAsync(Request request, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}