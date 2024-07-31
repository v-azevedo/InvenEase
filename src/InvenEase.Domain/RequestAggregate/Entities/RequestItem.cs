using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Domain.RequestAggregate.ValueObjects;

namespace InvenEase.Domain.RequestAggregate.Entities;

public sealed class RequestItem : Entity<RequestItemId>
{
    public ItemId ItemId { get; private set; }
    public int Quantity { get; private set; }

    private RequestItem(
        RequestItemId requestItemId,
        ItemId itemId,
        int quantity) : base(requestItemId)
    {
        Quantity = quantity;
        ItemId = itemId;
    }

    public static RequestItem Create(int quantity, ItemId itemId)
    {
        return new RequestItem(
            RequestItemId.CreateUnique(),
            itemId,
            quantity);
    }

#pragma warning disable CS8618
    private RequestItem()
    {
    }
}