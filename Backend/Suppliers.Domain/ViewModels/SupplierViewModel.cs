namespace Suppliers.Domain.ViewModels;
public class SupplierViewModel
{
    public ulong Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string SocialNumber { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<ContactViewModel> Contacts { get; set; }
}
