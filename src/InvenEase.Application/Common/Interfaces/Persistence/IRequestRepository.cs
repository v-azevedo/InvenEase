using InvenEase.Domain.RequestAggregate;

namespace InvenEase.Application.Common.Interfaces.Persistence;

public interface IRequestRepository
{
    Task CreateAsync(Request request, CancellationToken cancellationToken);
}