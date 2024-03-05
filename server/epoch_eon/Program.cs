using EpochEon.Config;
using EpochEon.Configuration;
using Prueba.Filters;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var mvcBuilder = services.AddControllers(cfg =>
{
    cfg.Filters.Add(typeof(AppExceptionFilter));
});

services.AddSingleton<ILoggerFactory, LoggerFactory>();
services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
services.AddLogging(loggingBuilder => loggingBuilder
    .AddConsole()
    .AddDebug()
    .SetMinimumLevel(LogLevel.Debug));

//SwaggerConfiguration.Configure(builder);
MappersConfiguration.Configure(builder);
RepositoriesConfiguration.Configure(builder);
ServicesConfiguration.Configure(builder);
ValidatorsConfiguration.Configure(builder, mvcBuilder);
AuthConfiguration.Configure(builder);
SerializationConfiguration.Configure(builder);
IndexingConfiguration.Configure(builder);

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
