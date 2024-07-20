using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequestAggregate.Entities;
using InvenEase.Domain.RequestAggregate.ValueObjects;
using InvenEase.Domain.RequesterAggregate.ValueObjects;
using InvenEase.Domain.StockistAggregate.ValueObjects;

namespace InvenEase.Domain.RequestAggregate;

public sealed class Request : AggregateRoot<RequestId>
{
    private readonly List<RequestObject> _objectsList = [];
    private readonly List<OrderId> _ordersList = [];

    public string Description { get; }
    public Status Status { get; }
    public Urgency Urgency { get; }
    public bool RequesterDelivered { get; }
    public IReadOnlyList<RequestObject> ObjectsList =>
        _objectsList.AsReadOnly();
    public IReadOnlyList<OrderId> OrdersList =>
        _ordersList.AsReadOnly();
    public RequesterId RequesterId { get; }
    public StockistId StockistId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Request(
        RequestId id,
        string description,
        Status status,
        Urgency urgency,
        bool requesterDelivered,
        RequesterId requesterId,
        StockistId stockistId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Description = description;
        Status = status;
        Urgency = urgency;
        RequesterDelivered = requesterDelivered;
        RequesterId = requesterId;
        StockistId = stockistId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Request Create(string description, Urgency urgency, RequesterId requesterId, StockistId stockistId)
    {
        return new Request(
            RequestId.CreateUnique(),
            description,
            Status.Pending,
            urgency,
            false,
            requesterId,
            stockistId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}