namespace Suppliers.Domain.Entities;
public class PaginatedList<BaseEntity>
{
    public int TotalItems { get; set; }
    public ICollection<BaseEntity> Items { get; set; }

    public PaginatedList(int totalCount, ICollection<BaseEntity> items)
    {
        TotalItems = totalCount;
        Items = items;
    }
}
