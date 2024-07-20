using InvenEase.Domain.Common.Models;
using InvenEase.Domain.OrderAggregate.ValueObjects;

namespace InvenEase.Domain.OrderAggregate.Entities;

public sealed class OrderObject : Entity<OrderObjectId>
{
    public int Quantity { get; }

    public OrderObject(
        OrderObjectId id,
        int quantity) : base(id)
    {
        Quantity = quantity;
    }

    public static OrderObject Create(int quantity)
    {
        return new OrderObject(
            OrderObjectId.CreateUnique(),
            quantity);
    }
}