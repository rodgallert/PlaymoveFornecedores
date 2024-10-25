using Suppliers.Domain.Entities;
using Suppliers.Domain.Interfaces.Repositories;

namespace Suppliers.Data.Repositories;
public class ContactRepository : Repository<Contact>, IContactRepository
{
    public ContactRepository(SuppliersContext context) : base(context)
    {
    }
}
