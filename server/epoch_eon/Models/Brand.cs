using Microsoft.EntityFrameworkCore;

namespace Prueba.Models
{
    [Index(nameof(Name), IsUnique = true)]

    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}