using ErrorOr;

namespace InvenEase.Domain.Common.Errors;

public static partial class Errors
{
    public static class Item
    {
        public static Error NotFound => Error.NotFound(
            code: "Item.NotFound",
            description: "No matching item found with the given Id.");
    }
}