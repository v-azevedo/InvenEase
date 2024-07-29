using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.ItemAggregate;

namespace InvenEase.Infrastructure.Persistence.Repositories;

public class ItemRepository(InvenEaseDbContext dbContext) : IItemRepository
{
    private readonly InvenEaseDbContext _dbContext = dbContext;

    public void Add(Item item)
    {
        _dbContext.Add(item);
        _dbContext.SaveChanges();
    }
}