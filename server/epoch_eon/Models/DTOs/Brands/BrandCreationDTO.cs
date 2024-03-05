namespace EpochEon.Models.DTOs.Categories
{
    public class BrandCreationDTO
    {
        // Only used for GetOrCreate
        public int? Id { get; set; }
        public string Name { get; set; } = "";
    }
}
