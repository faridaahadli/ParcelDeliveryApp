using FluentValidation;
using OrderDelivery.Infrastructure.Commands;

namespace OrderDeliveryService.API.Validators
{
    public class UpdateOrderByStaffValidator:AbstractValidator<UpdateOrderByStaffCommand>
    {
        public UpdateOrderByStaffValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("This filed is required");
            RuleFor(x => x.Status).NotNull().WithMessage("This filed is required");
        }
    }
}
