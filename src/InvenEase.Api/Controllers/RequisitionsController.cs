using InvenEase.Application.Requisitions.Commands.CreateRequisition;
using InvenEase.Application.Requisitions.Queries.GetRequisitions;
using InvenEase.Contracts.Requisitions;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("[controller]")]
public class RequisitionsController(IMapper mapper, ISender mediator) : ApiController
{
    [HttpPost("{requesterId:Guid}")]
    public async Task<IActionResult> CreateRequisition(CreateRequisitionRequest request, Guid requesterId)
    {
        var command = mapper.Map<CreateRequisitionCommand>((request, requesterId));

        var result = await mediator.Send(command);

        return result.Match(
            requisition => Ok(mapper.Map<RequisitionResponse>(requisition)),
            errors => Problem(errors));
    }

    [HttpGet("{requesterId:Guid}")]
    public async Task<IActionResult> GetRequisitionsByRequester(Guid requesterId)
    {
        var result = await mediator.Send(new GetByRequesterQuery(requesterId));

        return result.Match(
            requisitions => Ok(mapper.Map<List<RequisitionResponse>>(requisitions)),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetRequisitions()
    {
        var result = await mediator.Send(new GetRequisitionsQuery());

        return result.Match(
            requisitions => Ok(mapper.Map<List<RequisitionResponse>>(requisitions)),
            errors => Problem(errors));
    }
}