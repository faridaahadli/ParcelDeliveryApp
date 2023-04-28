using FluentValidation;
using OrderDelivery.Infrastructure.Commands;

namespace OrderDeliveryService.API.Validators
{
    public class CreateOrderValidator: AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("This field is required");
            RuleFor(x => x.Address).NotNull().WithMessage("This field is required");
            RuleFor(x => x.Phone).NotNull().WithMessage("This field is required");
            RuleFor(x => x.DeliveryTypeId).NotNull().WithMessage("This field is required");
            RuleFor(x => x.AuthorId).NotNull().WithMessage("This field is required");
        }
       
    }
}
