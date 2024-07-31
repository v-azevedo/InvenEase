using InvenEase.Application.Items.Commands.CreateItem;
using InvenEase.Application.Items.Commands.DeleteItem;
using InvenEase.Application.Items.Commands.UpdateItem;
using InvenEase.Application.Items.Queries.GetItem;
using InvenEase.Application.Items.Queries.GetItems;
using InvenEase.Contracts.Items;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.Controllers;

[Route("[controller]")]
public class ItemsController(IMapper mapper, ISender mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateItem(CreateItemRequest request)
    {
        var command = mapper.Map<CreateItemCommand>(request);

        var createItemResult = await mediator.Send(command);

        return createItemResult.Match(
            item => Ok(mapper.Map<ItemResponse>(item)),
            errors => Problem(errors));
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateItem(Guid id, UpdateItemRequest request)
    {
        var command = mapper.Map<UpdateItemCommand>((request, id));

        var updateItemResult = await mediator.Send(command);

        return updateItemResult.Match(
            item => Ok(mapper.Map<ItemResponse>(item)),
            errors => Problem(errors));
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetItem(Guid id)
    {
        var query = mapper.Map<GetItemQuery>(id);

        var getItemResult = await mediator.Send(query);

        return getItemResult.Match(
            item => Ok(mapper.Map<ItemResponse>(item)),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var query = new GetItemsQuery();

        var getItemsResult = await mediator.Send(query);

        return getItemsResult.Match(
            items => Ok(mapper.Map<IEnumerable<ItemResponse>>(items)),
            Problem);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var command = mapper.Map<DeleteItemCommand>(id);

        var deleteItemResult = await mediator.Send(command);

        return deleteItemResult.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }
}