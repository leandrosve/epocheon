using FluentValidation;
using Prueba.Models.DTOs.Auth;
using System.Text.RegularExpressions;

namespace EpochEon.Validators.Auth
{
    public class SignupDataValidator : AbstractValidator<SignupDataDTO>
    {

        public SignupDataValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email)
                .NotNull().WithMessage("email_required")
                .NotEmpty().WithMessage("email_required")
                .EmailAddress().WithMessage("email_invalid"); ;
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("username_required")
                .MaximumLength(100).WithMessage("username_invalid")
                .MinimumLength(5).WithMessage("username_invalid");

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("password_invalid")
                .Length(8, 200).WithMessage("password_invalid")
                .Matches(hasNumber).WithMessage("password_insecure")
                .Matches(hasLowerChar).WithMessage("password_insecure")
                .Matches(hasUpperChar).WithMessage("password_insecure");
        }

    }
}
