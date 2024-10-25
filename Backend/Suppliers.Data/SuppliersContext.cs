using Microsoft.EntityFrameworkCore;
using Suppliers.Domain.Entities;

namespace Suppliers.Data;
public partial class SuppliersContext(DbContextOptions opt) : DbContext(opt)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
