using Suppliers.Domain.Entities;
using Suppliers.Domain.ViewModels;
using X.PagedList;

namespace Suppliers.Domain.Interfaces.Services;
public interface ISupplierService
{
    Task<SupplierViewModel> GetAsync(ulong id);
    Task<PaginatedList<SupplierViewModel>> GetAsync(int page, int size);
    Task<SupplierViewModel> AddAsync(SupplierViewModel supplier);
    Task UpdateAsync(SupplierViewModel supplier, ulong id);
    Task DeleteAsync(SupplierViewModel supplier, ulong id);
    Task<PaginatedList<SupplierViewModel>> SearchAsync(string query, CancellationToken ct, int page, int size);
}
