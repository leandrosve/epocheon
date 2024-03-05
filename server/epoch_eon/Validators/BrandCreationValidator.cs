using EpochEon.Models.DTOs.Categories;
using FluentValidation;

namespace Prueba.Validators
{
    public class BrandCreationValidator : AbstractValidator<BrandCreationDTO>
    {

        public BrandCreationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("name_required");
        }
    }
}
