using core.ValueObjects;
using FluentValidation;

namespace core.Validators
{
    public class TelephoneValidator : AbstractValidator<Telephone>
    {
        public TelephoneValidator()
        {
            RuleFor(t => t.DDD)
                .NotEmpty().WithMessage("DDD is required")
                .Length(2).WithMessage("The DDD must contain 02 characters")
                .Matches("^[0-9]+$").WithMessage("The DDD must contain only numbers");

            RuleFor(t => t.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\d{8,9}$").WithMessage("The phone number must contain between 8 and 9 characters and only numbers");
        }
    }
}