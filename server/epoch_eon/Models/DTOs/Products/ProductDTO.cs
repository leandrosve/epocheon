using EpochEon.Models.DTOs.Categories;
using Prueba.Models;

namespace EpochEon.Models.DTOs.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public long CreatedAt { get; set; }
        public string Title { get; set; } = "";
        public string Sku { get; set; } = "";
        public string Description { get; set; } = "";
        public string Specs { get; set; } = "";
        public float Price { get; set; }
        public string? Status { get; set; }
        public CategoryDTO Category { get; set; } = null!;
        public BrandDTO Brand { get; set; } = null!;

        public List<ProductImageDTO> Images { get; set; } = new List<ProductImageDTO>();

    }
}
