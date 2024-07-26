using ErrorOr;

using MediatR;

namespace InvenEase.Application.Items.Commands.DeleteItem;

public record DeleteItemCommand(Guid Id) : IRequest<ErrorOr<Success>>;