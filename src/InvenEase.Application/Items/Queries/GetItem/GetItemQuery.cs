using ErrorOr;

using InvenEase.Domain.ItemAggregate;

using MediatR;

namespace InvenEase.Application.Items.Queries.GetItem;

public record GetItemQuery(Guid Id) : IRequest<ErrorOr<Item>>;