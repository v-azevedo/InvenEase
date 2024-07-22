using FluentValidation;

namespace InvenEase.Application.Items.Commands.CreateItem;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Dimensions).ChildRules(dimensions =>
        {
            dimensions.RuleFor(x => x.Length).GreaterThan(0);
            dimensions.RuleFor(x => x.Width).GreaterThan(0);
            dimensions.RuleFor(x => x.Height).GreaterThan(0);
            dimensions.RuleFor(x => x.Weight).GreaterThan(0);
        });
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.MinimumQuantity).GreaterThan(0);
    }
}