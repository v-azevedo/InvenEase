using InvenEase.Domain.ItemAggregate.ValueObjects;

using Item = InvenEase.Domain.ItemAggregate.Item;

namespace InvenEase.Application.Common.Interfaces.Persistence;

public interface IItemRepository
{
    Task CreateAsync(Item item, CancellationToken cancellationToken);
    Task UpdateAsync(Item item, CancellationToken cancellationToken);
    Task<Item?> GetByIdAsync(ItemId id, CancellationToken cancellationToken);
    Task<List<Item>> GetAllAsync(CancellationToken cancellationToken);
}