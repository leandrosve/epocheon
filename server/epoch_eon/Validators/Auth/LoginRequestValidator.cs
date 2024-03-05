using FluentValidation;
using Prueba.Models.DTOs.Auth;
using System.Text.RegularExpressions;

namespace EpochEon.Validators.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDTO>
    {

        public LoginRequestValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("username_required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("password_required");
        }

    }
}
