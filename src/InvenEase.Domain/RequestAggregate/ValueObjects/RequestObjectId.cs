using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.RequestAggregate.ValueObjects;

public sealed class RequestObjectId : ValueObject
{
    public Guid Value { get; }

    private RequestObjectId(Guid value)
    {
        Value = value;
    }

    public static RequestObjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}