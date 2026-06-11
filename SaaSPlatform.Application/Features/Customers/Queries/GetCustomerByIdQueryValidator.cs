using FluentValidation;

namespace SaaSPlatform.Application.Features.Customers.Queries;

public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();
    }
}
