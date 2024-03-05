using EpochEon.Models.DTOs.Products;
using EpochEon.Models;
using EpochEon.Utils;
using Prueba.Models;
using EpochEon.Mappings;

namespace EpochEon.Mappers
{
    public class ProductMapperService : IMapperService<Product, ProductDTO>
    {

        private readonly Dictionary<ProductStatus, string> statusDict = new Dictionary<ProductStatus, string>(){
                { ProductStatus.DRAFTED, "DRAFTED" },
                { ProductStatus.PUBLISHED, "PUBLISHED" },
                { ProductStatus.HIDDEN, "HIDDEN" },
            };

        public ProductDTO Map(Product product)
        {
            var category = product.Category;
            var brand = product.Brand;
            var images = product.Images;

            var dto = new ProductDTO
            {
                Id = product.Id,
                CreatedAt = DateUtils.ConvertToTimestamp(product.CreatedAt),
                Title = product.Title,
                Description = product.Description,
                Specs = product.Specs,
                Sku = product.Sku,
                Price = product.Price,
                Category = new Models.DTOs.Categories.CategoryDTO { Id = category.Id, ImageUrl = category.ImageUrl, Title = category.Title },
                Images = images.Select(i => new ProductImageDTO { Id = i.Id, DisplayOrder = i.DisplayOrder, Title = i.Title, Url = i.Url }).ToList(),
                Status = statusDict[product.Status],
                Brand = new Models.DTOs.Categories.BrandDTO { Id = brand.Id, Name = brand.Name}
            };

            return dto;
        }

    }
}
