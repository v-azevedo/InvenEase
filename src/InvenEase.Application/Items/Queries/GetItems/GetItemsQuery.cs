using ErrorOr;

using InvenEase.Domain.ItemAggregate;

using MediatR;

namespace InvenEase.Application.Items.Queries.GetItems;

public record GetItemsQuery : IRequest<ErrorOr<List<Item>>>;