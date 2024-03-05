namespace EpochEon.Config
{
    public static class SwaggerConfiguration
    {

        public static void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
