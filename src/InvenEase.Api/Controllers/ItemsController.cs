using InvenEase.Application.Items.Commands.CreateItem;
using InvenEase.Contracts.Items;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("/items")]
public class ItemsController(IMapper mapper, ISender mediator) : ApiController
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> CreateItem(CreateItemRequest request)
    {
        var command = _mapper.Map<CreateItemCommand>(request);

        var createItemResult = await _mediator.Send(command);

        return createItemResult.Match(
            item => Ok(_mapper.Map<ItemResponse>(item)),
            errors => Problem(errors));
    }
}