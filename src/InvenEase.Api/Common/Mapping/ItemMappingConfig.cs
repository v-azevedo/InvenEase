using InvenEase.Application.Items.Commands.CreateItem;
using InvenEase.Application.Items.Commands.DeleteItem;
using InvenEase.Application.Items.Commands.UpdateItem;
using InvenEase.Application.Items.Queries.GetItem;
using InvenEase.Contracts.Items;
using InvenEase.Domain.ItemAggregate;

using Mapster;

namespace InvenEase.Api.Common.Mapping;

public class ItemMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateItemRequest, CreateItemCommand>()
            .Map(dest => dest, src => src);

        config.NewConfig<Item, ItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.RequisitionIds, src => src.RequisitionIds.Select(requisitionId => requisitionId.Value))
            .Map(dest => dest.OrderIds, src => src.OrderIds.Select(orderId => orderId.Value));

        config.NewConfig<(UpdateItemRequest request, Guid Id), UpdateItemCommand>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Item, src => src.request);

        config.NewConfig<Guid, GetItemQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<Guid, DeleteItemCommand>()
            .Map(dest => dest.ItemId, src => src);
    }
}