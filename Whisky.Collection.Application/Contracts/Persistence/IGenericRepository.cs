using System.Collections.ObjectModel;
using Whisky.Collection.Domain.Common;

namespace Whisky.Collection.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    // Operations for every database table to carry out
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
