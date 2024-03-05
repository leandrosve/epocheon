using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class AdminUser
    {
        public int Id { get; set; }
        public DateTime JoinedAt { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }

    }
}
