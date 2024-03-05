using EpochEon.Services.Implementations;
using EpochEon.Services.Interfaces;

namespace EpochEon.Configuration
{
    public class IndexingConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddScoped<IProductsIndexingService, ProductsIndexingService>();
        }
    }
}
