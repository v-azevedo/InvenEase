using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Domain.RequestAggregate;
using InvenEase.Domain.RequestAggregate.ValueObjects;
using InvenEase.Domain.RequesterAggregate.ValueObjects;
using InvenEase.Domain.StockistAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenEase.Infrastructure.Requests.Repository;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        ConfigureRequestTable(builder);
        ConfigureRequestItemsTable(builder);
        ConfigureRequestOrderIdsTable(builder);
    }

    private static void ConfigureRequestItemsTable(EntityTypeBuilder<Request> builder)
    {
        builder.OwnsMany(r => r.Items, rib =>
        {
            rib.ToTable("RequestItems");

            rib.WithOwner().HasForeignKey("RequestId");

            rib.HasKey("Id", "RequestId");

            rib.Property(ri => ri.Id)
                .HasColumnName("RequestItemId")
                .HasConversion(
                    id => id.Value,
                    value => RequestItemId.Create(value));

            rib.Property(ri => ri.ItemId)
                .HasConversion(
                    id => id.Value,
                    value => ItemId.Create(value));
        });

        builder.Metadata.FindNavigation(nameof(Request.Items))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureRequestOrderIdsTable(EntityTypeBuilder<Request> builder)
    {
        builder.OwnsMany(r => r.OrderIds, oib =>
        {
            oib.ToTable("RequestOrderIds");

            oib.WithOwner().HasForeignKey("RequestId");

            oib.HasKey("Id");

            oib.Property(ri => ri.Value)
                .HasColumnName("OrderId");
        });

        builder.Metadata.FindNavigation(nameof(Request.OrderIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureRequestTable(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasConversion(
                id => id.Value,
                value => RequestId.Create(value));

        builder.Property(r => r.Description)
            .HasMaxLength(200);

        builder.Property(r => r.RequesterId)
            .HasConversion(
                id => id.Value,
                value => RequesterId.Create(value));

        builder.Property(r => r.StockistId)
            .HasConversion(
                id => id.Value,
                value => StockistId.Create(value));
    }
}