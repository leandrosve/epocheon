using EpochEon.Models.DTOs.Categories;
using FluentValidation;

namespace Prueba.Validators
{
    public class CategoryCreationValidator : AbstractValidator<CategoryCreationDTO>
    {

        public CategoryCreationValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("title_required");
        }
 
    }
}
