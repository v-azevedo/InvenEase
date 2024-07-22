using ErrorOr;

using InvenEase.Domain.ItemAggregate;

using MediatR;

namespace InvenEase.Application.Items.Commands.CreateItem;

public record CreateItemCommand(
    string Name,
    string Description,
    string Code,
    string ImageUrl,
    DimensionsCommand Dimensions,
    int Quantity,
    int MinimumQuantity
) : IRequest<ErrorOr<Item>>;

public record DimensionsCommand(
    double Length,
    double Width,
    double Height,
    double Weight
);