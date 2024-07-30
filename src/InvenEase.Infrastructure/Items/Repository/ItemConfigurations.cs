using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ItemAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenEase.Infrastructure.Items.Repository;

public class ItemConfigurations : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        ConfigureItemTable(builder);
        ConfigureItemRequestIdsTable(builder);
        ConfigureItemOrderIdsTable(builder);
    }

    private static void ConfigureItemRequestIdsTable(EntityTypeBuilder<Item> builder)
    {
        builder.OwnsMany(i => i.RequestIds, rib =>
        {
            rib.ToTable("ItemRequestIds");

            rib.WithOwner().HasForeignKey("ItemId");

            rib.HasKey("Id");

            rib.Property(ri => ri.Value)
                .HasColumnName("RequestId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Item.RequestIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureItemOrderIdsTable(EntityTypeBuilder<Item> builder)
    {
        builder.OwnsMany(i => i.OrderIds, oib =>
       {
           oib.ToTable("ItemOrderIds");

           oib.WithOwner().HasForeignKey("ItemId");

           oib.HasKey("Id");

           oib.Property(ri => ri.Value)
                .HasColumnName("OrderId")
                .ValueGeneratedNever();
       });

        builder.Metadata.FindNavigation(nameof(Item.OrderIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureItemTable(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            /* .ValueGeneratedNever() */

            .HasConversion(
                id => id.Value,
                value => ItemId.Create(value));

        builder.Property(i => i.Name)
            .HasMaxLength(100);
        builder.Property(i => i.Description)
            .HasMaxLength(500);

        builder.OwnsOne(i => i.Dimensions);
    }
}