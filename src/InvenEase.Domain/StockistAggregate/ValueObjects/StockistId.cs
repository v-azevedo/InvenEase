using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.StockistAggregate.ValueObjects;

public sealed class StockistId : ValueObject
{
    public Guid Value { get; }

    private StockistId(Guid value)
    {
        Value = value;
    }

    public static StockistId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}