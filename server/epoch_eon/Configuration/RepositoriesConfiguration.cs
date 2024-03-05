using EpochEon.Mappers;
using EpochEon.Mappings;
using EpochEon.Models.DTOs.Products;
using EpochEon.Services.Implementations;
using Prueba.Data;
using Prueba.Models;
using Prueba.Repositories.Implementations;
using Prueba.Repositories;
using Prueba.Services.Implementations;
namespace EpochEon.Config
{
    public static class RepositoriesConfiguration
    {

        public static void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddDbContext<AppDBContext>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IBrandsRepository, BrandsRepository>();
        }
    }
}
