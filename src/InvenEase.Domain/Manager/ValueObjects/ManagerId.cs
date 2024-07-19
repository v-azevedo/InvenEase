using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.Request.ValueObjects;

public sealed class ManagerId : ValueObject
{
    public Guid Value { get; }

    private ManagerId(Guid value)
    {
        Value = value;
    }

    public static ManagerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}