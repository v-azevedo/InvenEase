using FluentAssertions;
using InvenEase.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InvenEase.Api.UnitTests.Controllers;

public class RequestsControllerTests
{
    [Fact]
    public void ListRequests_WhenNoResults_ReturnEmptyList()
    {
        // Arrange
        var controller = new RequestsController();

        // Act
        var result = controller.ListRequests();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        result.As<OkObjectResult>().Value.Should().Be(Array.Empty<string>());
    }
}