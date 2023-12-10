using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Whisky.Collection.Application.Contracts.Persistence;
using WhiskyCollectionPersistence.DatabaseContext;
using WhiskyCollectionPersistence.Repository;
using MyWhiskyDomain = Whisky.Collection.Domain.MyWhisky;

namespace Whisky.Collection.Application.UnitTests.Features.MyWhisky.Repository;

public class MyWhiskyRepositoryNoDITests
{
    private readonly MyWhiskyDatabaseContext _databaseContext;
    private readonly MyWhiskyRepository _repository;

    public MyWhiskyRepositoryNoDITests()
    {
        var databasePath = @"C:\Users\pierr\source\repos\MyProject\Whisky.Collection\WhiskyCollectionPersistence\Database\Whisky.Collection.db";

        var options = new DbContextOptionsBuilder<MyWhiskyDatabaseContext>()
            .UseSqlite($"Data Source={databasePath}")
            .Options;

        _databaseContext = new MyWhiskyDatabaseContext(options);
        _repository = new MyWhiskyRepository(_databaseContext);
    }

    [Fact]
    public async Task RealDatabaseIsMyWhiskyUniqueReturnsTrue()
    {
        // Arrange
        var uniqueWhisky = new MyWhiskyDomain
        {
            Id = 4,
            WhiskyName = "UniqueTest",
            ProducerName = "UniqueTest",
            WhiskyYearStatement = 12,
            BottleDescription = "Highland Single Malt Scotch Whisky",
            AlkoholProcent = 40,
            BottleContentMilliliter = 700
        };

        // Act
        var isUnique = await _repository.IsMyWhiskyUnique(
            uniqueWhisky.ProducerName,
            uniqueWhisky.WhiskyName,
            uniqueWhisky.WhiskyYearStatement);

        // Assert
        Assert.True(isUnique);
    }

    [Fact]
    public async Task RealDatabaseIsMyWhiskyUniqueReturnsFalse()
    {
        // Arrange
        var uniqueWhisky = new MyWhiskyDomain
        {
            Id = 1,
            WhiskyName = "Macallan",
            ProducerName = "Double Cask",
            WhiskyYearStatement = 12
        };

        // Act
        var isUnique = await _repository.IsMyWhiskyUnique(
            uniqueWhisky.ProducerName,
            uniqueWhisky.WhiskyName,
            uniqueWhisky.WhiskyYearStatement);

        // Assert
        Assert.False(isUnique);
    }
}
