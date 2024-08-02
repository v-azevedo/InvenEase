using InvenEase.Application.Requisitions.Commands.CreateRequisition;
using InvenEase.Contracts.Requisitions;
using InvenEase.Domain.RequisitionAggregate;
using InvenEase.Domain.RequisitionAggregate.Entities;

using Mapster;

namespace InvenEase.Api.Common.Mapping;

public class RequisitionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateRequisitionRequest request, Guid requesterId), CreateRequisitionCommand>()
            .Map(dest => dest.RequesterId, src => src.requesterId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Requisition, RequisitionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.RequesterId, src => src.RequesterId.Value);

        config.NewConfig<RequisitionItem, RequisitionItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.ItemId, src => src.ItemId.Value);
    }
}