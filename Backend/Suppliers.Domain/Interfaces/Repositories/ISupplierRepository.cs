using Suppliers.Domain.Entities;

namespace Suppliers.Domain.Interfaces.Repositories;
public interface ISupplierRepository : IRepository<Supplier>
{
    Task<bool> IsTaxIdentificationNumberRegisteredAsync(string taxIdentificationNumber);
    Task<ICollection<Supplier>> SearchSuppliersAsync(string search, CancellationToken ct);
}
