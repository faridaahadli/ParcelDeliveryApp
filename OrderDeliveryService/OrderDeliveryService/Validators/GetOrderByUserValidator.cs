using FluentValidation;
using OrderDelivery.Infrastructure.Queries;

namespace OrderDeliveryService.API.Validators
{
    public class GetOrderByUserValidator: AbstractValidator<GetOrdersByUserQuery>
    {
        public GetOrderByUserValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("This filed is required");
        }
    }

}
