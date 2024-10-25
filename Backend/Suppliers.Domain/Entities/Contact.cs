namespace Suppliers.Domain.Entities;
public class Contact : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public ulong SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
}
