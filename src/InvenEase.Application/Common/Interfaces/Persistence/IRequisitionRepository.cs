using InvenEase.Domain.RequisitionAggregate;

namespace InvenEase.Application.Common.Interfaces.Persistence;

public interface IRequisitionRepository
{
    Task CreateAsync(Requisition requisition, CancellationToken cancellationToken);
}