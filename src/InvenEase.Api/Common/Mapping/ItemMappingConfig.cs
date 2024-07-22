using InvenEase.Application.Items.Commands.CreateItem;
using InvenEase.Contracts.Items;
using InvenEase.Domain.ItemAggregate;

using Mapster;

namespace InvenEase.Api.Common.Mapping;

public class ItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateItemRequest, CreateItemCommand>();

        config.NewConfig<Item, ItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.RequestIds, src => src.RequestIds.Select(requestId => requestId.Value))
            .Map(dest => dest.OrderIds, src => src.OrderIds.Select(orderId => orderId.Value));
    }
}