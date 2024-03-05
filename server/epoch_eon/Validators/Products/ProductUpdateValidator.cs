using EpochEon.Models.DTOs.Categories;
using EpochEon.Models.DTOs.Products;
using FluentValidation;

namespace EpochEon.Validators.Products
{
    public class ProductUpdateValidator : AbstractValidator<ProductUpdateDTO>
    {

        public ProductUpdateValidator()
        {
            RuleFor(x => x.Title)
                .MinimumLength(1).WithMessage("title_required");
            RuleFor(x => x.Description)
                .MinimumLength(1).WithMessage("description_required");
            RuleFor(x => x.Sku)
                .MinimumLength(1).WithMessage("sku_required");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("price_required");
            RuleFor(x => x.Specs)
                .MinimumLength(1).WithMessage("specs_required");
            When(x => x.Status != null, () => RuleFor(x => x.Status).Must(BeValidStatus).WithMessage("invalid_status"));
            When(x => x.Category != null && x.Category.Id == null, 
                () => RuleFor(x => x.Category.Title).NotEmpty().WithMessage("category_title_required"));
            When(x => x.Category != null && string.IsNullOrWhiteSpace(x.Category.Title),
               () => RuleFor(x => x.Category.Id).NotNull().WithMessage("category_id_required"));

            When(x => x.Brand != null && x.Brand.Id == null,
                () => RuleFor(x => x.Brand.Name).NotEmpty().WithMessage("brand_name_required"));
            When(x => x.Brand != null && string.IsNullOrWhiteSpace(x.Brand.Name),
               () => RuleFor(x => x.Brand.Id).NotNull().WithMessage("brand_id_required"));
        }

        private bool BeValidStatus(string? status)
        {
            if (status == null) return true;
            string[] validStatuses = ["DRAFTED", "PUBLISHED", "HIDDEN"];
            return validStatuses.Contains(status);
        }

    }
}
