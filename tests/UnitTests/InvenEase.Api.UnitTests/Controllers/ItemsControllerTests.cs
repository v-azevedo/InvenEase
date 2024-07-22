using FakeItEasy;

using FluentAssertions;

using InvenEase.Api.Controllers;
using InvenEase.Application.Items.Commands.CreateItem;
using InvenEase.Contracts.Items;
using InvenEase.Domain.ItemAggregate;
using InvenEase.Domain.ObjectAggregate.ValueObjects;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.UnitTests.Controllers;

public class ItemsControllerTests
{
    private readonly ISender _mediator = A.Fake<ISender>();
    private readonly IMapper _mapper = A.Fake<IMapper>();
    private readonly ItemsController _controller;

    public ItemsControllerTests()
    {
        // SUT
        _controller = new ItemsController(_mapper, _mediator);
    }

    [Fact]
    public async Task CreateItem_WhenCalled_ReturnOk()
    {
        // Arrange
        var request = A.Fake<CreateItemRequest>();
        A.CallTo(() => _mediator.Send(A<CreateItemCommand>._, default))
            .Returns(A.Dummy<Item>());

        // Act
        var result = await _controller.CreateItem(request);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
    }

    private class DummyUserFactory : DummyFactory<Item>
    {
        protected override Item Create()
        {
            Item item = Item.Create(
                name: string.Empty,
                description: string.Empty,
                code: string.Empty,
                imageUrl: string.Empty,
                dimensions: Dimensions.CreateNew(0, 0, 0, 0),
                quantity: 0,
                minimumQuantity: 0);

            return item;
        }
    }
}