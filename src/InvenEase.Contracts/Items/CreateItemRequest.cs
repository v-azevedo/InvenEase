namespace InvenEase.Contracts.Items;

public record CreateItemRequest(
    string Name,
    string Description,
    string Code,
    string ImageUrl,
    DimensionsRequest Dimensions,
    int Quantity,
    int MinimumQuantity
);

public record DimensionsRequest(
    double Length,
    double Width,
    double Height,
    double Weight
);