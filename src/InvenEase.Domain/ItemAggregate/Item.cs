using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Domain.ObjectAggregate.ValueObjects;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequestAggregate.ValueObjects;

namespace InvenEase.Domain.ItemAggregate;

public sealed class Item : AggregateRoot<ItemId>
{
    private readonly List<RequestId> _requestIds = [];
    private readonly List<OrderId> _orderIds = [];

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Code { get; private set; }
    public string ImageUrl { get; private set; }
    public Dimensions Dimensions { get; private set; }
    public int Quantity { get; private set; }
    public int MinimumQuantity { get; private set; }
    public IReadOnlyList<RequestId> RequestIds => _requestIds;
    public IReadOnlyList<OrderId> OrderIds => _orderIds;
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

#pragma warning disable CS8618
    private Item()
    {
    }
}