using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.RequisitionAggregate;
using InvenEase.Infrastructure.Persistence;

namespace InvenEase.Infrastructure.Requisitions.Repository;

public class RequisitionsRepository(InvenEaseDbContext dbContext) : IRequisitionRepository
{
    public async Task CreateAsync(Requisition requisition, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(requisition, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}