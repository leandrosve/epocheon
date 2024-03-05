namespace EpochEon.Models.DTOs.Products
{

    public class ProductSearchDTO
    {
        public string? SearchTerm { get; set; }
        public PriceRangeDTO? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public SortByDTO? Sort { get; set; }
    }

    public class PriceRangeDTO
    {
        public float? Min { get; set; }
        public float? Max { get; set; }
    }

    public class SortByDTO
    {
        public string Field { get; set; } = "";
        public string Order { get; set; } = "DESC";
    }

}
