using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.RequestAggregate.ValueObjects;

public sealed class RequestId : ValueObject
{
    public Guid Value { get; }

    private RequestId(Guid value)
    {
        Value = value;
    }

    public static RequestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}