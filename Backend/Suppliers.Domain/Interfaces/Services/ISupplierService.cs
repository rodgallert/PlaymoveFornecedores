using Suppliers.Domain.ViewModels;

namespace Suppliers.Domain.Interfaces.Services;
public interface ISupplierService
{
    Task<SupplierViewModel> GetAsync(ulong id);
    Task<ICollection<SupplierViewModel>> GetAsync(int page, int size);
    Task<SupplierViewModel> AddAsync(SupplierViewModel supplier);
    Task UpdateAsync(SupplierViewModel supplier, ulong id);
    Task DeleteAsync(SupplierViewModel supplier, ulong id);
}
