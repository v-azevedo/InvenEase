using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.RequisitionAggregate;
using InvenEase.Infrastructure.Persistence;

namespace InvenEase.Infrastructure.Requisitions.Repository;

public class RequisitionsRepository(InvenEaseDbContext dbContext) : IRequisitionRepository
{
    public async Task CreateAsync(Requisition request, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(request, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}