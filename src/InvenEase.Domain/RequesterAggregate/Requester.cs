using InvenEase.Domain.Common.Models;
using InvenEase.Domain.RequesterAggregate.ValueObjects;
using InvenEase.Domain.RequisitionAggregate.ValueObjects;
using InvenEase.Domain.UserAggregate.ValueObjects;

namespace InvenEase.Domain.RequesterAggregate;

public sealed class Requester : AggregateRoot<RequesterId>
{
    private readonly List<RequisitionId> _requisitionIds = [];

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfileImage { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<RequisitionId> RequisitionIds =>
        _requisitionIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Requester(
        RequesterId id,
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

    public static Requester Create(string firstName, string lastName, string profileImage, UserId userId)
    {
        return new Requester(
            RequesterId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Requester()
    {
    }
}