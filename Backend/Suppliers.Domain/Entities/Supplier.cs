namespace Suppliers.Domain.Entities;
public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string SocialNumber { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; }
}
