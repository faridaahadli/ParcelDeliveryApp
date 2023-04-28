using FluentValidation;
using OrderDelivery.Infrastructure.Commands;

namespace OrderDeliveryService.API.Validators
{
    public class CreateDeliveryValidator:AbstractValidator<CreateDeliveryCommand>
    {
        public CreateDeliveryValidator()
        {
            RuleFor(x => x.CourierId).NotNull().WithMessage("This field is required");
            RuleFor(x => x.OrderId).NotNull().WithMessage("This field is required");
        }
    }
}
