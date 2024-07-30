using InvenEase.Domain.Common.Models;
using InvenEase.Domain.UserAggregate.ValueObjects;

namespace InvenEase.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    private readonly List<Role> _roles = [];
    private readonly List<Permission> _permissions = [];

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public IReadOnlyList<Role> Roles => _roles.AsReadOnly();
    public IReadOnlyList<Permission> Permissions => _permissions.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddRole(Role role)
    {
        _roles.Add(role);
    }

#pragma warning disable CS8618
    private User()
    {
        // Required by EF Core
    }
}