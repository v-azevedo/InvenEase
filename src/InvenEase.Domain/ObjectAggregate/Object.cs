using InvenEase.Domain.Common.Models;
using InvenEase.Domain.ObjectAggregate.ValueObjects;
using InvenEase.Domain.OrderAggregate.ValueObjects;
using InvenEase.Domain.RequestAggregate.ValueObjects;

namespace InvenEase.Domain.ObjectAggregate;

public sealed class Object : AggregateRoot<ObjectId>
{
    private readonly List<RequestId> _requestsList = [];
    private readonly List<OrderId> _ordersList = [];
    public string Name { get; }
    public string Description { get; }
    public string Code { get; }
    public string ImageUrl { get; }
    public Dimensions Dimensions { get; }
    public int Quantity { get; }
    public int MinimumQuantity { get; }
    public IReadOnlyList<RequestId> RequestIds => _requestsList;
    public IReadOnlyList<OrderId> OrderIds => _ordersList;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Object(
        ObjectId id,
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

    public static Object Create(
        string name,
        string description,
        string code,
        string imageUrl,
        Dimensions dimensions,
        int quantity,
        int minimumQuantity)
    {
        return new Object(
            ObjectId.CreateUnique(),
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
}