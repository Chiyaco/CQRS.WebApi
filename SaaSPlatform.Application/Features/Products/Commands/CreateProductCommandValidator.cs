using FluentValidation;

namespace SaaSPlatform.Application.Features.Products.Commands;

public  class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
             .Must(x => !string.IsNullOrWhiteSpace(x));

        RuleFor(p => p.Price)
            .GreaterThan(0);
    }
}
