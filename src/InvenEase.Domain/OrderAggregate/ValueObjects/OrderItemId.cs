using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.OrderAggregate.ValueObjects;

public sealed class OrderItemId : ValueObject
{
    public Guid Value { get; }

    private OrderItemId(Guid value)
    {
        Value = value;
    }

    public static OrderItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}