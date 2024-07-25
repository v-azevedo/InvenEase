using ErrorOr;

using InvenEase.Application.Items.Commands.Common;

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