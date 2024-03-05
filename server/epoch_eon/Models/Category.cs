using Microsoft.EntityFrameworkCore;

namespace Prueba.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Category
    {
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? ImageUrl { get; set; }
    }
}