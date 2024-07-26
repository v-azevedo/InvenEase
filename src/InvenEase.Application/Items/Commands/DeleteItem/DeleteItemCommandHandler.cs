using ErrorOr;

using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Domain.Common.Errors;
using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ItemAggregate.ValueObjects;

using MediatR;

namespace InvenEase.Application.Items.Commands.DeleteItem;

public class DeleteItemCommandHandler(IItemRepository itemRepository) : IRequestHandler<DeleteItemCommand, ErrorOr<Success>>
{
    private readonly IItemRepository _itemRepository = itemRepository;

    public async Task<ErrorOr<Success>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        if (await _itemRepository.GetByIdAsync(ItemId.Create(request.Id), cancellationToken) is not Item item)
        {
            return Errors.Item.NotFound;
        }

        await _itemRepository.DeleteAsync(item, cancellationToken);

        return Result.Success;
    }
}