using Microsoft.Extensions.DependencyInjection;
using Suppliers.Domain.Interfaces.Services;
using Suppliers.Services.ApiServices;

namespace Suppliers.Services;
public static class ServiceManager
{
    public static void InjectServices(this IServiceCollection services)
    {
        services.AddScoped<ISupplierService, SupplierService>();
    }
}
