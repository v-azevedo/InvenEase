using InvenEase.Application.Requisitions.Commands.CreateRequisition;
using InvenEase.Contracts.Requisitions;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("[controller]")]
public class RequisitionsController(IMapper mapper, ISender mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateRequisition(CreateRequisitionRequest request)
    {
        var command = mapper.Map<CreateRequisitionCommand>(request);

        var result = await mediator.Send(command);

        return result.Match(
            request => Ok(mapper.Map<RequisitionResponse>(request)),
            errors => Problem(errors));
    }
}