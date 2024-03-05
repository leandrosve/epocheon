namespace EpochEon.Models.DTOs.Products
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public string Title { get; set; } = "";
        public int DisplayOrder { get; set; }
    }
}
