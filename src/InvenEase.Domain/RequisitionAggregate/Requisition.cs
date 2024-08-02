using InvenEase.Domain.Common.Enums;
using InvenEase.Domain.Common.Models;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequesterAggregate.ValueObjects;
using InvenEase.Domain.RequisitionAggregate.Entities;
using InvenEase.Domain.RequisitionAggregate.ValueObjects;
using InvenEase.Domain.StockistAggregate.ValueObjects;

namespace InvenEase.Domain.RequisitionAggregate;

public sealed class Requisition : AggregateRoot<RequisitionId>
{
    private readonly List<OrderId> _orderIds = [];

    public string Description { get; private set; }
    public Status Status { get; private set; }
    public Urgency Urgency { get; private set; }
    public bool RequesterDelivered { get; private set; }
    public IReadOnlyList<RequisitionItem> Items { get; private set; }
    public IReadOnlyList<OrderId> OrderIds =>
        _orderIds.AsReadOnly();
    public RequesterId RequesterId { get; private set; }
    public StockistId? StockistId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Requisition(
        RequisitionId id,
        string description,
        Status status,
        Urgency urgency,
        bool requesterDelivered,
        RequesterId requesterId,
        List<RequisitionItem> items,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Description = description;
        Status = status;
        Urgency = urgency;
        RequesterDelivered = requesterDelivered;
        RequesterId = requesterId;
        Items = items;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Requisition Create(string description, Urgency urgency, RequesterId requesterId, List<RequisitionItem> items)
    {
        return new Requisition(
            RequisitionId.CreateUnique(),
            description,
            Status.Pending,
            urgency,
            false,
            requesterId,
            items,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618
    private Requisition()
    {
    }
}