﻿using Whisky.Collection.Domain;

namespace Whisky.Collection.Application.Contracts.Persistence;

public interface IMyWhiskyRepository : IGenericRepository<MyWhisky>
{
    Task<bool> IsMyWhiskyUnique(string producerName, string whiskyName, int whiskyYearStatement);
}