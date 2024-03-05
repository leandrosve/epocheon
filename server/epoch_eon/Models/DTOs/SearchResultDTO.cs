namespace EpochEon.Models.DTOs
{
    public class SearchResultDTO<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public List<T> Results { get; set; } = new List<T>();
    }
}
