using FluentValidation;
using OrderDelivery.Infrastructure.Commands;

namespace OrderDeliveryService.API.Validators
{
    public class UpdateOrderByUserValidator: AbstractValidator<UpdateOrderByUserCommand>
    {
        public UpdateOrderByUserValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("This filed is required");
            RuleFor(x => x.Address).NotNull().WithMessage("This filed is required");
        }
    }
}
