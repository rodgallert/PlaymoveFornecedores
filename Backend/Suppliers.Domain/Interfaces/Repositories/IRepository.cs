using Suppliers.Domain.Entities;

namespace Suppliers.Domain.Interfaces.Repositories;
public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetAsync(ulong id);
    Task<ICollection<T>> GetAsync(int skip, int take);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
