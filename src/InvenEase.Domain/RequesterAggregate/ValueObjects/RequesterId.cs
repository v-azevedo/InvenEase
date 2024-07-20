using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.RequesterAggregate.ValueObjects;

public sealed class RequesterId : ValueObject
{
    public Guid Value { get; }

    private RequesterId(Guid value)
    {
        Value = value;
    }

    public static RequesterId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}