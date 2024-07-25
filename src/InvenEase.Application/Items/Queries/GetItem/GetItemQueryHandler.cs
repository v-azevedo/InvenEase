using ErrorOr;

using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.Common.Errors;

using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ItemAggregate.ValueObjects;

using MediatR;

namespace InvenEase.Application.Items.Queries.GetItem;

public class GetItemQueryHandler(IItemRepository itemRepository) : IRequestHandler<GetItemQuery, ErrorOr<Item>>
{
    private readonly IItemRepository _itemRepository = itemRepository;

    public async Task<ErrorOr<Item>> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        return await _itemRepository.GetByIdAsync(ItemId.Create(request.Id), cancellationToken) is Item item
            ? item
            : Errors.Item.NotFound;
    }
}