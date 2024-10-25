using Suppliers.Domain.Entities;
using Suppliers.Domain.Interfaces.Repositories;

namespace Suppliers.Data.Repositories;
public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(SuppliersContext context) : base(context)
    {
    }
}
