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
        // No Tracking improve preformance
        // Don't need to track for changes when we use API
        // (As we don't know when changes will be submited)
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
#nullable disable
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id);
    }
#nullable enable
    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
