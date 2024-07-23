using InvenEase.Domain.ItemAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvenEase.Infrastructure.Persistence;

public class InvenEaseDbContext : DbContext
{
    public InvenEaseDbContext(DbContextOptions<InvenEaseDbContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(InvenEaseDbContext).Assembly);

        modelBuilder.Model
            .GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                    .Where(p => p.IsPrimaryKey())
                    .ToList()
                    .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}