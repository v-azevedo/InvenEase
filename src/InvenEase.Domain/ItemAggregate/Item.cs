using ErrorOr;

using InvenEase.Domain.Common.Errors;

using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Domain.ObjectAggregate.ValueObjects;
using InvenEase.Domain.OrderAggregate;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequisitionAggregate;
using InvenEase.Domain.RequisitionAggregate.ValueObjects;

namespace InvenEase.Domain.ItemAggregate;

public sealed class Item : AggregateRoot<ItemId>
{
    private readonly List<RequisitionId> _requestIds = [];
    private readonly List<OrderId> _orderIds = [];

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Code { get; private set; }
    public string ImageUrl { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public int Quantity { get; private set; }
    public int MinimumQuantity { get; private set; }
    public IReadOnlyList<RequisitionId> RequisitionIds => _requestIds.AsReadOnly();
    public IReadOnlyList<OrderId> OrderIds => _orderIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Item(
        ItemId id,
        string name,
        string description,
        string code,
        string imageUrl,
        Dimensions dimensions,
        int quantity,
        int minimumQuantity,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        Code = code;
        ImageUrl = imageUrl;
        Dimensions = dimensions;
        Quantity = quantity;
        MinimumQuantity = minimumQuantity;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Item Create(
        string name,
        string description,
        string code,
        string imageUrl,
        Dimensions dimensions,
        int quantity,
        int minimumQuantity)
    {
        return new Item(
            ItemId.CreateUnique(),
            name,
            description,
            code,
            imageUrl,
            dimensions,
            quantity,
            minimumQuantity,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void Update(
        string name,
        string description,
        string code,
        string imageUrl,
        Dimensions dimensions,
        int quantity,
        int minimumQuantity)
    {
        Name = name;
        Description = description;
        Code = code;
        ImageUrl = imageUrl;
        Dimensions = dimensions;
        Quantity = quantity;
        MinimumQuantity = minimumQuantity;
        UpdatedDateTime = DateTime.UtcNow;
    }

    public ErrorOr<Success> IncludeRequisition(Requisition request)
    {
        if (_requestIds.Contains(request.Id))
        {
            return Errors.Item.AlreadyIncluded(nameof(Requisition));
        }

        _requestIds.Add(request.Id);

        return Result.Success;
    }

    public ErrorOr<Success> IncludeOrder(Order order)
    {
        if (_orderIds.Contains(order.Id))
        {
            return Errors.Item.AlreadyIncluded(nameof(Order));
        }

        _orderIds.Add(order.Id);

        return Result.Success;
    }

#pragma warning disable CS8618
    private Item()
    {
    }
}