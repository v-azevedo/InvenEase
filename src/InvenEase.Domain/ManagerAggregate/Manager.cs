using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ManagerAggregate.ValueObjects;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequestAggregate.ValueObjects;
using InvenEase.Domain.UserAggregate.ValueObjects;

namespace InvenEase.Domain.ManagerAggregate;

public sealed class Manager : AggregateRoot<ManagerId>
{
    private readonly List<OrderId> _ordersList = [];
    private readonly List<RequestId> _requestsList = [];

    public string FirstName { get; }
    public string LastName { get; }
    public Role Role { get; }
    public string ProfileImage { get; }
    public UserId UserId { get; }
    public IReadOnlyList<OrderId> OrdersList =>
        _ordersList.AsReadOnly();
    public IReadOnlyList<RequestId> RequestsList =>
        _requestsList.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Manager(
        ManagerId id,
        string firstName,
        string lastName,
        Role role,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Role = role;
        ProfileImage = profileImage;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Manager Create(string firstName, string lastName, string profileImage, UserId userId)
    {
        return new Manager(
            ManagerId.CreateUnique(),
            firstName,
            lastName,
            Role.Manager,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}