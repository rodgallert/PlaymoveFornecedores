using Microsoft.EntityFrameworkCore;
using Suppliers.Domain.Entities;
using Suppliers.Domain.Interfaces.Repositories;

namespace Suppliers.Data.Repositories;
public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(SuppliersContext context) : base(context)
    {
    }

    public async Task<bool> IsTaxIdentificationNumberRegisteredAsync(string taxIdentificationNumber)
    {
        return await _context.Suppliers
            .AnyAsync(s => s.TaxIdentificationNumber == taxIdentificationNumber);
    }

    public async Task<ICollection<Supplier>> SearchSuppliersAsync(string search, CancellationToken ct)
    {
        return await _context.Suppliers
            .Where(s => s.Name.ToLower().Contains(search.ToLower()) 
                || s.TaxIdentificationNumber.Contains(search))
            .ToListAsync(ct);
    }
}
