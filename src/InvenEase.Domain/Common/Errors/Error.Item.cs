using ErrorOr;

namespace InvenEase.Domain.Common.Errors;

public static partial class Errors
{
    public static class Item
    {
        public static Error NotFound => Error.NotFound(
            code: "Item.NotFound",
            description: "Item not found.");
        public static Error AlreadyIncluded(string type) => Error.Conflict(
            code: $"Item.{type}AlreadyIncluded",
            description: $"The {type} is already included in this item.");
    }
}