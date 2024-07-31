using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.RequisitionAggregate.ValueObjects;

public sealed class RequisitionItemId : ValueObject
{
    public Guid Value { get; }

    private RequisitionItemId(Guid value)
    {
        Value = value;
    }

    public static RequisitionItemId Create(Guid value)
    {
        return new(value);
    }

    public static RequisitionItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}