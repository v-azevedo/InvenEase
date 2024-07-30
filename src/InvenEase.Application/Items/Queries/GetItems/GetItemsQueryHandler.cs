using ErrorOr;

using InvenEase.Application.Common.Interfaces.Persistence;

using InvenEase.Domain.ItemAggregate;

using MediatR;

namespace InvenEase.Application.Items.Queries.GetItems;

public class GetItemsQueryHandler(IItemRepository itemRepository) : IRequestHandler<GetItemsQuery, ErrorOr<List<Item>>>
{
    private readonly IItemRepository _itemRepository = itemRepository;

    public async Task<ErrorOr<List<Item>>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        return await _itemRepository.GetAllAsync(cancellationToken);
    }
}