namespace Prueba.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public string Title { get; set; } = "";
        public int DisplayOrder { get; set; }
        public int ProductId { get; set; }
    }
}