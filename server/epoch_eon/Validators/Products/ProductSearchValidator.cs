using EpochEon.Models.DTOs.Categories;
using EpochEon.Models.DTOs.Products;
using FluentValidation;

namespace EpochEon.Validators.Products
{
    public class ProductSearchValidator : AbstractValidator<ProductSearchDTO>
    {

        private List<string> _allowed_filters = ["title", "price", "createdAt"];
        public ProductSearchValidator()
        {
            RuleFor(x => x.SearchTerm)
                .MinimumLength(1).WithMessage("title_required");
            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100).WithMessage("invalid_page_size");
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("invalid_page_number");

            When(x => x.Sort != null, () => RuleFor(x => x.Sort.Field).Must(x => _allowed_filters.Contains(x)).WithMessage("invalid_sort_field"));
            When(x => x.Sort != null, () => RuleFor(x => x.Sort.Order).Must(x => x.ToLower() == "asc" || x.ToLower() == "desc").WithMessage("invalid_sort_order"));
        }
    }
}
