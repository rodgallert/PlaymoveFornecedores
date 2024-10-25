using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Suppliers.Data;
public static class ServiceManager
{
    public static void InjectData(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentNullException("Connection string is missing");

        if (environment.IsDevelopment())
        {
            services.AddDbContext<SuppliersContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
        }
        else
        {
            services.AddDbContext<SuppliersContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        ConfigureRepositories(services);
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        
    }
}
