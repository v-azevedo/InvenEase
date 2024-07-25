using ErrorOr;

using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.Common.Errors;

using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ItemAggregate.ValueObjects;
using InvenEase.Domain.ObjectAggregate.ValueObjects;

using MediatR;

namespace InvenEase.Application.Items.Commands.UpdateItem;

public class UpdateItemCommandHandler(IItemRepository repository) : IRequestHandler<UpdateItemCommand, ErrorOr<Item>>
{
    private readonly IItemRepository _itemRepository = repository;

    public async Task<ErrorOr<Item>> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        if (await _itemRepository.GetByIdAsync(ItemId.Create(request.Id), cancellationToken) is not Item item)
        {
            return Errors.Item.NotFound;
        }

        item.Update(
            request.Item.Name,
            request.Item.Description,
            request.Item.Code,
            request.Item.ImageUrl,
            Dimensions.CreateNew(
                length: request.Item.Dimensions.Length,
                width: request.Item.Dimensions.Width,
                height: request.Item.Dimensions.Height,
                weight: request.Item.Dimensions.Weight),
            request.Item.Quantity,
            request.Item.MinimumQuantity);

        await _itemRepository.UpdateAsync(item, cancellationToken);

        return item;
    }
}