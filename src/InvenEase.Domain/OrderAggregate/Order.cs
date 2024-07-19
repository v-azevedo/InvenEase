using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.Request.ValueObjects;

namespace InvenEase.Domain.OrderAggregate;

public sealed class Order : AggregateRoot<OrderId>
{
    private readonly List<OrderObjectId> _objectsList = [];
    public string Description { get; }
    public Status Status { get; }
    public IReadOnlyList<OrderObjectId> ObjectsList =>
        _objectsList.AsReadOnly();
    public Urgency Urgency { get; }
    public bool Approved { get; }
    public string Invoice { get; }
    public string DeliveryNote { get; }
    public RequestId? RequestId { get; }
    public StockistId StockistId { get; }
    public ManagerId ManagerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Order(
        OrderId id,
        string description,
        Status status,
        Urgency urgency,
        bool approved,
        string invoice,
        string deliveryNote,
        RequestId? requestId,
        StockistId stockistId,
        ManagerId managerId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Description = description;
        Status = status;
        Urgency = urgency;
        Approved = approved;
        Invoice = invoice;
        DeliveryNote = deliveryNote;
        RequestId = requestId;
        StockistId = stockistId;
        ManagerId = managerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Order Create(string description, Urgency urgency, RequestId? requestId, StockistId stockistId, ManagerId managerId)
    {
        return new Order(
            OrderId.CreateUnique(),
            description,
            Status.Pending,
            urgency,
            false,
            string.Empty,
            string.Empty,
            requestId,
            stockistId,
            managerId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}