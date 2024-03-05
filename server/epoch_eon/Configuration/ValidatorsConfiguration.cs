using EpochEon.Validators.Auth;
using EpochEon.Validators.Products;
using FluentValidation.AspNetCore;
using FluentValidation;
using Prueba.Validators;

namespace EpochEon.Config
{
    public static class ValidatorsConfiguration
    {

        private static bool _enableCustomErrorDetail = true;
        public static void Configure(WebApplicationBuilder builder, IMvcBuilder mvcBuilder)
        {
            var services = builder.Services;
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<SignupDataValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CategoryCreationValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductCreationValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductUpdateValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductSearchValidator>();
            services.AddValidatorsFromAssemblyContaining<BrandCreationValidator>();



            ValidatorOptions.Global.PropertyNameResolver = (a, b, c) => b.Name.ToLowerInvariant();

            if (_enableCustomErrorDetail)
            {
                mvcBuilder.ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = CustomValidationErrorDetail.MakeValidationResponse;
                });
            }
        }
    }
}
