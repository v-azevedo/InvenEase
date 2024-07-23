using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.RequestAggregate.ValueObjects;
using InvenEase.Domain.RequesterAggregate.ValueObjects;
using InvenEase.Domain.UserAggregate.ValueObjects;

namespace InvenEase.Domain.RequesterAggregate;

public sealed class Requester : AggregateRoot<RequesterId>
{
    private readonly List<RequestId> _requestIds = [];

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Role Role { get; private set; }
    public string ProfileImage { get; private set; }
    public UserId UserId { get; private set; }
    public IReadOnlyList<RequestId> RequestIds =>
        _requestIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Requester(
        RequesterId id,
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

    public static Requester Create(string firstName, string lastName, string profileImage, UserId userId)
    {
        return new Requester(
            RequesterId.CreateUnique(),
            firstName,
            lastName,
            Role.Requester,
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