using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace InvenEase.Infrastructure.Items.Repository;

public class ItemRepository(InvenEaseDbContext dbContext) : IItemRepository
{
    public async Task CreateAsync(Item item, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(item, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Item item, CancellationToken cancellationToken)
    {
        dbContext.Update(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Item?> GetByIdAsync(ItemId id, CancellationToken cancellationToken)
    {
        return await dbContext.Items.FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task<List<Item>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Items.ToListAsync(cancellationToken);
    }

    public async Task DeleteAsync(Item item, CancellationToken cancellationToken)
    {
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}