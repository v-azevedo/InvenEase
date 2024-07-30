namespace InvenEase.Contracts.Items;

public record DimensionsRequest(
    double Length,
    double Width,
    double Height,
    double Weight
);