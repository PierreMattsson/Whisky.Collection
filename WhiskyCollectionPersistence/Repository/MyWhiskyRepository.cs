using Microsoft.EntityFrameworkCore;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Domain;
using WhiskyCollectionPersistence.DatabaseContext;

namespace WhiskyCollectionPersistence.Repository;

public class MyWhiskyRepository : GenericRepository<MyWhisky>, IMyWhiskyRepository
{
    // Take a copy from the IoC and use it here.
    // Call the base so we can use the "protected" _context and use it here.
    public MyWhiskyRepository(MyWhiskyDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsMyWhiskyUnique(
        string producerName, 
        string whiskyName, 
        int whiskyYearStatement)
    {
        return await _context.MyWhiskies.AnyAsync(
            q => q.ProducerName == producerName &&
            q.WhiskyName == whiskyName &&
            q.WhiskyYearStatement == whiskyYearStatement) == false;
    }
}
