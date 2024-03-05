using EpochEon.Models.DTOs.Categories;
using EpochEon.Models.DTOs.Products;
using FluentValidation;

namespace EpochEon.Validators.Products
{
    public class ProductCreationValidator : AbstractValidator<ProductCreationDTO>
    {

        public ProductCreationValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("title_required");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("description_required");
            RuleFor(x => x.Sku)
                .NotEmpty().WithMessage("sku_required");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("price_required")
                .GreaterThan(0).WithMessage("price_required");
            RuleFor(x => x.Specs)
                .NotEmpty().WithMessage("specs_required");

            RuleFor(x => x.Status)
               .NotEmpty().WithMessage("status_required")
                .Must(BeValidStatus).WithMessage("invalid_status");

            RuleFor(x => x.Category).NotNull().WithMessage("category_required");
            When(x => x.Category != null && x.Category.Id == null, () => RuleFor(x => x.Category.Title).NotEmpty().WithMessage("category_title_required"));
            When(x => x.Category != null && string.IsNullOrWhiteSpace(x.Category.Title), () => RuleFor(x => x.Category.Title).NotEmpty().WithMessage("category_id_required"));

            RuleFor(x => x.Brand).NotNull().WithMessage("brand_required");
            When(x => x.Brand != null && x.Brand.Id == null, () => RuleFor(x => x.Brand.Name).NotEmpty().WithMessage("brand_name_required"));
            When(x => x.Brand != null && string.IsNullOrWhiteSpace(x.Brand.Name), () => RuleFor(x => x.Brand.Name).NotEmpty().WithMessage("brand_id_required"));
        }

        private bool BeValidStatus(string status)
        {
            string[] validStatuses = ["DRAFTED", "PUBLISHED", "HIDDEN"];
            return validStatuses.Contains(status);
        }

    }
}
