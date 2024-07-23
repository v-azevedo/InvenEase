using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ManagerAggregate.ValueObjects;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequestAggregate.ValueObjects;
using InvenEase.Domain.StockistAggregate.ValueObjects;

namespace InvenEase.Domain.OrderAggregate;

public sealed class Order : AggregateRoot<OrderId>
{
    private readonly List<OrderItemId> _orderItemIds = [];
    public string Description { get; private set; }
    public Status Status { get; private set; }
    public IReadOnlyList<OrderItemId> OrderItemIds =>
        _orderItemIds.AsReadOnly();
    public Urgency Urgency { get; private set; }
    public bool Approved { get; private set; }
    public string Invoice { get; private set; }
    public string DeliveryNote { get; private set; }
    public RequestId? RequestId { get; private set; }
    public StockistId StockistId { get; private set; }
    public ManagerId ManagerId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

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

#pragma warning disable CS8618
    private Order()
    {
    }
}