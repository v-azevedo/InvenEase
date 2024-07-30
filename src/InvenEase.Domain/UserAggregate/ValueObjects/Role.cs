using InvenEase.Domain.Common.Models;

namespace InvenEase.Domain.UserAggregate.ValueObjects;

public sealed class Role : ValueObject
{
    public string Value { get; private set; }

    private Role(string value)
    {
        Value = value;
    }

    public static Role CreateNew(string value)
    {
        return new Role(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}