using Item = InvenEase.Domain.ItemAggregate.Item;

namespace InvenEase.Application.Common.Interfaces.Persistence;

public interface IItemRepository
{
    void Add(Item item);
}