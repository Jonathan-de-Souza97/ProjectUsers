using core.ValueObjects;
using FluentValidation;

namespace core.Validators
{
    public class TelephoneValidator : AbstractValidator<Telephone>
    {
        public TelephoneValidator()
        {
            RuleFor(t => t.DDD)
                .NotEmpty().WithMessage("DDD is required");
        }
    }
}