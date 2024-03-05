using EpochEon.Models.DTOs.Categories;
using Prueba.Models;

namespace EpochEon.Models.DTOs.Products
{
    public class ProductCreationDTO
    {
        public required string Sku { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = "";
        public string Specs { get; set; } = "";
        public float Price { get; set; }
        public CategoryCreationDTO Category { get; set; } = null!;
        public BrandCreationDTO Brand { get; set; } = null!;
        public List<string> ImageUrls { get; set; } = new List<string>();
        public string Status { get; set; } = "";

    }
}
