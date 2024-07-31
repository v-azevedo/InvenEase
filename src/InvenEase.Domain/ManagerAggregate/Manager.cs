using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ManagerAggregate.ValueObjects;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequisitionAggregate.ValueObjects;
using InvenEase.Domain.UserAggregate.ValueObjects;

namespace InvenEase.Domain.ManagerAggregate;

public sealed class Manager : AggregateRoot<ManagerId>
{
    private readonly List<OrderId> _ordersIds = [];
    private readonly List<RequisitionId> _requestsIds = [];

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<OrderId> OrderIds =>
        _ordersIds.AsReadOnly();
    public IReadOnlyList<RequisitionId> RequisitionIds =>
        _requestsIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Manager(
        ManagerId id,
        string firstName,
        string lastName,
        string profileImage,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
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
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Manager()
    {
    }
}