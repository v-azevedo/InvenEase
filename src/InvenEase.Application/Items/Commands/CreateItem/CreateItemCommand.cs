using ErrorOr;

using InvenEase.Application.Common.Security.Request;
using InvenEase.Application.Common.Security.Roles;

using InvenEase.Application.Items.Commands.Common;

using InvenEase.Domain.ItemAggregate;

namespace InvenEase.Application.Items.Commands.CreateItem;

[Authorize(Roles = Roles.Manager)]
public record CreateItemCommand(
    Guid? UserId,
    string Name,
    string Description,
    string Code,
    string ImageUrl,
    DimensionsCommand Dimensions,
    int Quantity,
    int MinimumQuantity
) : IAuthorizeableRequest<ErrorOr<Item>>;