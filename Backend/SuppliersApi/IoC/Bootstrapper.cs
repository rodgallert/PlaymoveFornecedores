using Suppliers.Data;
using Suppliers.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Suppliers.Api.IoC;

public static class Bootstrapper
{
    public static void RegisterServices(this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
    {

        services.AddControllers();

        services.InjectServices();
        services.InjectData(configuration, environment);

        services.AddHttpContextAccessor();
        services.AddHttpClient();

        services.AddAuthorization();
        services.AddAuthentication();

        services.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                   options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
               });
    }
}
