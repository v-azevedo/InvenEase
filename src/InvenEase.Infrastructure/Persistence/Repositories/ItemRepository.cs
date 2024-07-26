using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ItemAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;

namespace InvenEase.Infrastructure.Persistence.Repositories;

public class ItemRepository(InvenEaseDbContext dbContext) : IItemRepository
{
    private readonly InvenEaseDbContext _dbContext = dbContext;

    public async Task CreateAsync(Item item, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(item, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Item item, CancellationToken cancellationToken)
    {
        _dbContext.Update(item);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Item?> GetByIdAsync(ItemId id, CancellationToken cancellationToken)
    {
        return await _dbContext.Items.FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }

    public async Task<List<Item>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Items.ToListAsync(cancellationToken);
    }

    public async Task DeleteAsync(Item item, CancellationToken cancellationToken)
    {
        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}