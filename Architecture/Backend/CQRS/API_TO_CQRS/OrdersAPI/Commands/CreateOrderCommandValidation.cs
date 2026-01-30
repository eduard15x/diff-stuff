using FluentValidation;

namespace OrdersAPI.Commands;

public class CreateOrderCommandValidation: AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidation()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
        RuleFor(x => x.TotalCost).GreaterThan(0);
    }
}