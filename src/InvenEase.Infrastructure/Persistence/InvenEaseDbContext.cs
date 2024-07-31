using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.RequestAggregate;
using InvenEase.Domain.UserAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvenEase.Infrastructure.Persistence;

public class InvenEaseDbContext(DbContextOptions<InvenEaseDbContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Request> Requests { get; set; } = null!;

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