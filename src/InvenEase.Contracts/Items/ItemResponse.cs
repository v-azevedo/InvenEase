namespace InvenEase.Contracts.Items;

public record ItemResponse(
    string Id,
    string Name,
    string Description,
    string Code,
    string ImageUrl,
    DimensionsResponse Dimensions,
    int Quantity,
    int MinimumQuantity,
    List<string> RequisitionIds,
    List<string> OrderIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record DimensionsResponse(
    double Length,
    double Width,
    double Height,
    double Weight
);