namespace Suppliers.Domain.Entities;
public class Contact
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsActive { get; set; } = true;

    public ulong SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }
}
