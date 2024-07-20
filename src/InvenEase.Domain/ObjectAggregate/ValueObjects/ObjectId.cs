using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.ObjectAggregate.ValueObjects;

public sealed class ObjectId : ValueObject
{
    public Guid Value { get; }

    private ObjectId(Guid value)
    {
        Value = value;
    }

    public static ObjectId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}