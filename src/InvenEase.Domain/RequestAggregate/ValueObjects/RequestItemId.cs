using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.RequestAggregate.ValueObjects;

public sealed class RequestItemId : ValueObject
{
    public Guid Value { get; }

    private RequestItemId(Guid value)
    {
        Value = value;
    }

    public static RequestItemId Create(Guid value)
    {
        return new(value);
    }

    public static RequestItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}