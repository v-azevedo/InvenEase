using FluentValidation;

namespace InvenEase.Application.Items.Commands.UpdateItem;

public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    public UpdateItemCommandValidator()
    {
        RuleFor(x => x.Item.Name)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Item.Description)
            .NotEmpty()
            .MaximumLength(500);
        RuleFor(x => x.Item.Code).NotEmpty();
        RuleFor(x => x.Item.Dimensions).ChildRules(dimensions =>
        {
            dimensions.RuleFor(x => x.Length).NotEmpty();
            dimensions.RuleFor(x => x.Width).NotEmpty();
            dimensions.RuleFor(x => x.Height).NotEmpty();
            dimensions.RuleFor(x => x.Weight).NotEmpty();
        });
        RuleFor(x => x.Item.Quantity).NotEmpty();
        RuleFor(x => x.Item.MinimumQuantity).NotEmpty();
    }
}