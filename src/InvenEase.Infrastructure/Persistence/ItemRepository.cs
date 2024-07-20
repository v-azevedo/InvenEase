using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.ItemAggregate;

namespace InvenEase.Infrastructure.Persistence;

public class ItemRepository : IItemRepository
{
    private static readonly List<Item> _items = [];

    public void Add(Item item)
    {
        _items.Add(item);
    }
}