using System.Text.Json.Serialization;
using System.Text.Json;

namespace EpochEon.Config
{
    public static class SerializationConfiguration
    {

        public static void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
        }
    }
}
