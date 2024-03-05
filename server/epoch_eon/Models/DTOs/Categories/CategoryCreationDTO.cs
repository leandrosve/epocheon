namespace EpochEon.Models.DTOs.Categories
{
    public class CategoryCreationDTO
    {
        // Only used for get or create
        public int? Id { get; set; }
        public string Title { get; set; } = "";
        public string? ImageUrl { get; set; }
    }
}
