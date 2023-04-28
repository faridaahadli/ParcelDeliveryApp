using Auth.Infrastructure.Commands;
using FluentValidation;

namespace Auth.API.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("This field is required");
            RuleFor(x => x.Surname).NotNull().WithMessage("This field is required");
            RuleFor(x => x.Email).NotNull().WithMessage("This field is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x=>x.Phone).NotNull().WithMessage("This field is required")
                .MinimumLength(9).WithMessage("NUmber format is not correct");
            RuleFor(x=>x.Password).NotNull().WithMessage("This field is required")
                .MinimumLength(8).WithMessage("Minimum length is 8 for password")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password is not in the correct format.")
                .Equal(x=>x.ConfirmPassword).WithMessage("Paswords don't match");
           

        }
    }
}
