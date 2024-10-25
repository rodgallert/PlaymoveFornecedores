using Microsoft.EntityFrameworkCore;
using Suppliers.Domain.Entities;

namespace Suppliers.Data;
public partial class SuppliersContext : DbContext
{
    public SuppliersContext(DbContextOptions<SuppliersContext> dbContextOptions) : base(dbContextOptions)
    {
        var pendingMigrations = Database.GetPendingMigrationsAsync().Result;

        if (pendingMigrations.Any())
        {
            Database.Migrate();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
