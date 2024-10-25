using Suppliers.Domain.Interfaces.Repositories;
using Suppliers.Domain.Interfaces.Services;
using Suppliers.Domain.ViewModels;

namespace Suppliers.Services.ApiServices;
public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        this.supplierRepository = supplierRepository;
    }


    public Task<SupplierViewModel> AddAsync(SupplierViewModel supplier)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(SupplierViewModel supplier, ulong id)
    {
        throw new NotImplementedException();
    }

    public Task<SupplierViewModel> GetAsync(ulong id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<SupplierViewModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(SupplierViewModel supplier, ulong id)
    {
        throw new NotImplementedException();
    }
}
