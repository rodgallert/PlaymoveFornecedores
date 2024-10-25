namespace Suppliers.Domain.ViewModels;
public class ContactViewModel
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsActive { get; set; }

    public ulong SupplierId { get; set; }
}
