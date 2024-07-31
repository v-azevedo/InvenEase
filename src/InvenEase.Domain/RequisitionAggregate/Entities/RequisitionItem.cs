using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Domain.RequisitionAggregate.ValueObjects;

namespace InvenEase.Domain.RequisitionAggregate.Entities;

public sealed class RequisitionItem : Entity<RequisitionItemId>
{
    public ItemId ItemId { get; private set; }
    public int Quantity { get; private set; }

    private RequisitionItem(
        RequisitionItemId requestItemId,
        ItemId itemId,
        int quantity) : base(requestItemId)
    {
        Quantity = quantity;
        ItemId = itemId;
    }

    public static RequisitionItem Create(int quantity, ItemId itemId)
    {
        return new RequisitionItem(
            RequisitionItemId.CreateUnique(),
            itemId,
            quantity);
    }

#pragma warning disable CS8618
    private RequisitionItem()
    {
    }
}