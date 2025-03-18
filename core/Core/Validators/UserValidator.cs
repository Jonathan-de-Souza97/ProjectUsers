using core.Entity;
using FluentValidation;

namespace core.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("The name is required")
                .MaximumLength(50).WithMessage("The name must contain a maximum of 50 characters");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("The e-mail is required")
                .EmailAddress().WithMessage("This e-mail is invalid");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("The password is required")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, one special character, and be at least 8 characters long");

            RuleFor(u => u.Telephone)
                .NotEmpty().WithMessage("Telephone is required");
        }
    }
}