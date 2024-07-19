using InvenEase.Domain.Common.Models;
using InvenEase.Domain.Request.ValueObjects;

namespace InvenEase.Domain.Request.Entities;

public sealed class RequestObject : Entity<RequestObjectId>
{
    public int Quantity { get; }

    public RequestObject(
        RequestObjectId id,
        int quantity) : base(id)
    {
        Quantity = quantity;
    }

    public static RequestObject Create(int quantity)
    {
        return new RequestObject(
            RequestObjectId.CreateUnique(),
            quantity);
    }
}