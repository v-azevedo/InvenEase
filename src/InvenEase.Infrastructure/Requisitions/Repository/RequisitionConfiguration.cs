using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Domain.RequesterAggregate.ValueObjects;
using InvenEase.Domain.RequisitionAggregate;
using InvenEase.Domain.RequisitionAggregate.ValueObjects;
using InvenEase.Domain.StockistAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenEase.Infrastructure.Requisitions.Repository;

public class RequisitionConfiguration : IEntityTypeConfiguration<Requisition>
{
    public void Configure(EntityTypeBuilder<Requisition> builder)
    {
        ConfigureRequisitionTable(builder);
        ConfigureRequisitionItemsTable(builder);
        ConfigureRequisitionOrderIdsTable(builder);
    }

    private static void ConfigureRequisitionItemsTable(EntityTypeBuilder<Requisition> builder)
    {
        builder.OwnsMany(r => r.Items, rib =>
        {
            rib.ToTable("RequisitionItems");

            rib.WithOwner().HasForeignKey("RequisitionId");

            rib.HasKey("Id", "RequisitionId");

            rib.Property(ri => ri.Id)
                .HasColumnName("RequisitionItemId")
                .HasConversion(
                    id => id.Value,
                    value => RequisitionItemId.Create(value));

            rib.Property(ri => ri.ItemId)
                .HasConversion(
                    id => id.Value,
                    value => ItemId.Create(value));
        });

        builder.Metadata.FindNavigation(nameof(Requisition.Items))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureRequisitionOrderIdsTable(EntityTypeBuilder<Requisition> builder)
    {
        builder.OwnsMany(r => r.OrderIds, oib =>
        {
            oib.ToTable("RequisitionOrderIds");

            oib.WithOwner().HasForeignKey("RequisitionId");

            oib.HasKey("Id");

            oib.Property(ri => ri.Value)
                .HasColumnName("OrderId");
        });

        builder.Metadata.FindNavigation(nameof(Requisition.OrderIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureRequisitionTable(EntityTypeBuilder<Requisition> builder)
    {
        builder.ToTable("Requisitions");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasConversion(
                id => id.Value,
                value => RequisitionId.Create(value));

        builder.Property(r => r.Description)
            .HasMaxLength(200);

        builder.Property(r => r.RequesterId)
            .HasConversion(
                id => id.Value,
                value => RequesterId.Create(value));

        builder.Property(r => r.StockistId)
            .HasConversion(
                id => id!.Value,
                value => StockistId.Create(value))
            .IsRequired(false);
    }
}