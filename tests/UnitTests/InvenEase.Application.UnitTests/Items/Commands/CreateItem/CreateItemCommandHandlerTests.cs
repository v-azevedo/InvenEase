using FakeItEasy;

using FluentAssertions;

using InvenEase.Application.Common.Interfaces.Persistence;
using InvenEase.Application.Items.Commands.CreateItem;
using InvenEase.Domain.ItemAggregate;

namespace InvenEase.Application.UnitTests.Items.Commands.CreateItem;

public class CreateItemCommandHandlerTests
{
    private readonly IItemRepository _itemRepository = A.Fake<IItemRepository>();
    private readonly CreateItemCommandHandler _handler;

    public CreateItemCommandHandlerTests()
    {
        // SUT
        _handler = new CreateItemCommandHandler(_itemRepository);
    }

    [Fact]
    public async Task Handle_WhenCalled_CreateItem()
    {
        // Arrange
        var command = A.Fake<CreateItemCommand>();

        A.CallTo(() => _itemRepository.Add(A<Item>._));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        A.CallTo(() => _itemRepository.Add(A<Item>._)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task Handle_WhenCalled_ReturnCreatedItem()
    {
        // Arrange
        var command = A.Fake<CreateItemCommand>();

        A.CallTo(() => _itemRepository.Add(A<Item>._));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Value.Should().BeOfType<Item>();
    }
}