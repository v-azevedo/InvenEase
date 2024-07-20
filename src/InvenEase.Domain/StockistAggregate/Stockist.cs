using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.RequestAggregate.ValueObjects;
using InvenEase.Domain.StockistAggregate.ValueObjects;
using InvenEase.Domain.UserAggregate.ValueObjects;

namespace InvenEase.Domain.StockistAggregate;

public sealed class Stockist : AggregateRoot<StockistId>
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

    private Stockist(
        StockistId id,
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

    public static Stockist Create(string firstName, string lastName, string profileImage, UserId userId)
    {
        return new Stockist(
            StockistId.CreateUnique(),
            firstName,
            lastName,
            Role.Stockist,
            profileImage,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}