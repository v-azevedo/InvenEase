namespace InvenEase.Contracts.Items;

public record UpdateItemRequest(
    string Name,
    string Description,
    string Code,
    string ImageUrl,
    DimensionsRequest Dimensions,
    int Quantity,
    int MinimumQuantity
);
