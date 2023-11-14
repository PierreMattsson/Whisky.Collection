﻿using Whisky.Collection.Domain.Common;

namespace Whisky.Collection.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    // Operations for every database table to carry out
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
