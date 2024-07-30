using ErrorOr;

using InvenEase.Application.Common.Security.Request;
using InvenEase.Application.Common.Security.Roles;

using InvenEase.Application.Items.Commands.Common;

using InvenEase.Domain.ItemAggregate;

namespace InvenEase.Application.Items.Commands.UpdateItem;

[Authorize(Roles = Roles.Manager)]
public record UpdateItemCommand(
    Guid? UserId,
    Guid Id,
    ItemCommand Item
) : IAuthorizeableRequest<ErrorOr<Item>>;