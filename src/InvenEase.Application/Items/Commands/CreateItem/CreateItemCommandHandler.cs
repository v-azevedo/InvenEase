using ErrorOr;

using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ObjectAggregate.ValueObjects;

using MediatR;

namespace InvenEase.Application.Items.Commands.CreateItem;

public class CreateItemCommandHandler(
    IItemRepository itemRepository) : IRequestHandler<CreateItemCommand, ErrorOr<Item>>
{
    private readonly IItemRepository _itemRepository = itemRepository;

    public async Task<ErrorOr<Item>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        // Create Item
        var createdItem = Item.Create(
            name: request.Name,
            description: request.Description,
            code: request.Code,
            imageUrl: request.ImageUrl,
            dimensions: Dimensions.CreateNew(
                length: request.Dimensions.Length,
                width: request.Dimensions.Width,
                height: request.Dimensions.Height,
                weight: request.Dimensions.Weight),
            quantity: request.Quantity,
            minimumQuantity: request.MinimumQuantity);

        // Persist Item
        await _itemRepository.CreateAsync(createdItem, cancellationToken);

        // Return Item
        return createdItem;
    }
}
