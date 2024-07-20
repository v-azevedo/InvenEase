using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.OrderAggregate.ValueObjects;

public sealed class OrderObjectId : ValueObject
{
    public Guid Value { get; }

    private OrderObjectId(Guid value)
    {
        Value = value;
    }

    public static OrderObjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}