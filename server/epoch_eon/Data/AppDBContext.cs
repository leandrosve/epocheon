using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Data
{
    public class AppDBContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public AppDBContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
