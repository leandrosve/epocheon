using EpochEon.Models.DTOs.Categories;
using Prueba.Models;

namespace EpochEon.Models.DTOs.Products
{
    public class ProductUpdateDTO
    {
        public string? Sku { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Specs { get; set; } 
        public float? Price { get; set; }
        public CategoryCreationDTO? Category { get; set; }
        public BrandCreationDTO? Brand{ get; set; }

        public List<string>? ImageUrls { get; set; } = new List<string>();
        public string? Status { get; set; }
    }
}
