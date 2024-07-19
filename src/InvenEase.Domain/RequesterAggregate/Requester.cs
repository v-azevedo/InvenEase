using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.Request.ValueObjects;

namespace InvenEase.Domain.RequesterAggregate;

public sealed class Requester : AggregateRoot<RequesterId>
{
    private readonly List<RequestId> _requestsList = [];

    public string FirstName { get; }
    public string LastName { get; }
    public Role Role { get; }
    public string ProfileImage { get; }
    public UserId UserId { get; }
    public IReadOnlyList<RequestId> RequestsList =>
        _requestsList.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

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
}