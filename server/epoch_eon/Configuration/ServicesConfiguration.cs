using EpochEon.Services.Implementations;
using Prueba.Services.Implementations;
using Prueba.Services.Interfaces;

namespace EpochEon.Config
{
    public static class ServicesConfiguration
    {

        public static void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IProductsService, ProductService>();
            services.AddScoped<IBrandsService, BrandsService>();
            services.AddScoped<IPublicProductsService, PublicProductService>();

        }
    }
}
