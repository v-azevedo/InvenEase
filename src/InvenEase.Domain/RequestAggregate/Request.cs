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
    private readonly List<RequestItem> _requestItems = [];
    private readonly List<OrderId> _orderIds = [];

    public string Description { get; private set; }
    public Status Status { get; private set; }
    public Urgency Urgency { get; private set; }
    public bool RequesterDelivered { get; private set; }
    public IReadOnlyList<RequestItem> RequestItems =>
        _requestItems.AsReadOnly();
    public IReadOnlyList<OrderId> OrderIds =>
        _orderIds.AsReadOnly();
    public RequesterId RequesterId { get; private set; }
    public StockistId StockistId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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

#pragma warning disable CS8618
    private Request()
    {
    }
}