﻿using Microsoft.EntityFrameworkCore;
using Suppliers.Domain.Entities;
using Suppliers.Domain.Interfaces.Repositories;

namespace Suppliers.Data.Repositories;
public class Repository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly SuppliersContext _context;

    public Repository(SuppliersContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        var obj = await _context
                .Set<T>()
                .AddAsync(entity);
        await _context.SaveChangesAsync();

        return obj.Entity;
    }

    public async Task DeleteAsync(T entity)
    {
        entity.IsActive = false;
        await UpdateAsync(entity);
    }

    public async Task<T> GetAsync(ulong id)
    {
        return await _context
                .Set<T>()
                .FirstOrDefaultAsync(x => x.IsActive
                    && x.Id == id);
    }

    public async Task<ICollection<T>> GetAsync()
    {
        return await _context
            .Set<T>()
            .Where(x => x.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        entity.UpdatedAt = DateTime.Now;
        var obj = _context
            .Set<T>()
            .Update(entity);
        await _context.SaveChangesAsync();
    }
}
