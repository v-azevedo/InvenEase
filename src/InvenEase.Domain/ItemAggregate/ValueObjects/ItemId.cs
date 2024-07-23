using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.ItemAggregate.ValueObjects;

public sealed class ItemId : ValueObject
{
    public Guid Value { get; }

    private ItemId(Guid value)
    {
        Value = value;
    }

    public static ItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ItemId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}