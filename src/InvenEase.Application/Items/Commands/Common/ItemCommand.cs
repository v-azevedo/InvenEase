namespace InvenEase.Application.Items.Commands.Common;

public record ItemCommand(
    string Name,
    string Description,
    string Code,
    string ImageUrl,
    DimensionsCommand Dimensions,
    int Quantity,
    int MinimumQuantity
    );