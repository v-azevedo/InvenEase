using InvenEase.Domain.Common.Models;
using InvenEase.Domain.OrderAggregate.ValueObjects;

namespace InvenEase.Domain.OrderAggregate.Entities;

public sealed class OrderItem : Entity<OrderItemId>
{
    public int Quantity { get; }

    public OrderItem(
        OrderItemId id,
        int quantity) : base(id)
    {
        Quantity = quantity;
    }

    public static OrderItem Create(int quantity)
    {
        return new OrderItem(
            OrderItemId.CreateUnique(),
            quantity);
    }
}