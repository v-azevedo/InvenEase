using InvenEase.Domain.Common.Models;
using InvenEase.Domain.RequestAggregate.ValueObjects;

namespace InvenEase.Domain.RequestAggregate.Entities;

public sealed class RequestItem : Entity<RequestItemId>
{
    public int Quantity { get; }

    public RequestItem(
        RequestItemId id,
        int quantity) : base(id)
    {
        Quantity = quantity;
    }

    public static RequestItem Create(int quantity)
    {
        return new RequestItem(
            RequestItemId.CreateUnique(),
            quantity);
    }
}