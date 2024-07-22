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
        await Task.CompletedTask;

        // Create Item
        var item = Item.Create(
            name: request.Name,
            description: request.Description,
            code: request.Code,
            imageUrl: request.ImageUrl,
            dimensions: Dimensions.CreateNew(
                request.Dimensions.Length,
                request.Dimensions.Width,
                request.Dimensions.Height,
                request.Dimensions.Weight),
            quantity: request.Quantity,
            minimumQuantity: request.MinimumQuantity);

        // Persist Item
        _itemRepository.Add(item);

        // Return Item
        return item;
    }
}
