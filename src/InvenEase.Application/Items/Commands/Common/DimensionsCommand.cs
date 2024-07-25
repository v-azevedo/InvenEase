namespace InvenEase.Application.Items.Commands.Common;

public record DimensionsCommand(
    double Length,
    double Width,
    double Height,
    double Weight
);