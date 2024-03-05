using EpochEon.Models;

namespace Prueba.Models
{
    public class Product
    {
        public required DateTime CreatedAt { get; set; }
        public int Id { get; set; }
        public string Sku { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Specs { get; set; } = "";
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ProductStatus Status { get; set; } = 0;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;


    }
}