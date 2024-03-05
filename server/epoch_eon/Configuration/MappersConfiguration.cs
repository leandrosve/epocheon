using EpochEon.Mappers;
using EpochEon.Mappings;
using EpochEon.Models.DTOs.Products;
using Prueba.Models;

namespace EpochEon.Config
{
    public static class MappersConfiguration
    {

        public static void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddScoped<IMapperService<Product, ProductDTO>, ProductMapperService>();
        }
    }
}
