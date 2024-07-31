using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.RequisitionAggregate.ValueObjects;

public sealed class RequisitionId : ValueObject
{
    public Guid Value { get; }

    private RequisitionId(Guid value)
    {
        Value = value;
    }

    public static RequisitionId Create(Guid value)
    {
        return new(value);
    }

    public static RequisitionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}