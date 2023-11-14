using Microsoft.EntityFrameworkCore;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Domain.Common;
using WhiskyCollectionPersistence.DatabaseContext;

namespace WhiskyCollectionPersistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly MyWhiskyDatabaseContext _context;

    public GenericRepository(MyWhiskyDatabaseContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
