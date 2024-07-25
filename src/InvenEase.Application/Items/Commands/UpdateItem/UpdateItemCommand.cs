using ErrorOr;

using InvenEase.Application.Items.Commands.Common;

using InvenEase.Domain.ItemAggregate;

using MediatR;

namespace InvenEase.Application.Items.Commands.UpdateItem;

public record UpdateItemCommand(
    Guid Id,
    ItemCommand Item
) : IRequest<ErrorOr<Item>>;
