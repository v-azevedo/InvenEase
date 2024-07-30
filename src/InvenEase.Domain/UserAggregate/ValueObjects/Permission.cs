using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.UserAggregate.ValueObjects;

public sealed class Permission : ValueObject
{
    public string Value { get; private set; }

    private Permission(string value)
    {
        Value = value;
    }

    public static Permission CreateNew(string value)
    {
        return new Permission(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}