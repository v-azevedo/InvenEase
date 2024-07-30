using ErrorOr;

using InvenEase.Application.Common.Security.Request;
using InvenEase.Application.Common.Security.Roles;

namespace InvenEase.Application.Items.Commands.DeleteItem;

[Authorize(Roles = Roles.Manager)]
public record DeleteItemCommand(
    Guid? UserId,
    Guid ItemId) : IAuthorizeableRequest<ErrorOr<Success>>;