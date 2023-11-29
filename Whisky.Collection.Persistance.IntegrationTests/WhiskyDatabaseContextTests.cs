using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Whisky.Collection.Domain;
using WhiskyCollectionPersistence.DatabaseContext;

namespace Whisky.Collection.Persistance.IntegrationTests;

public class WhiskyDatabaseContextTests
{
    private MyWhiskyDatabaseContext _whiskyDatabaseContext;
    //private readonly string _userId;
    //private readonly Mock<IUserService> _userServiceMock;

    public WhiskyDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<MyWhiskyDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _whiskyDatabaseContext = new MyWhiskyDatabaseContext(dbOptions);
    }

    [Fact]
    public async void Save_SetDateCreatedValue()
    {
        // Arrange
        var myWhisky = new MyWhisky
        {
            Id = 1,
            WhiskyName = "Test",
            ProducerName = "Test"
        };

        // Act
        await _whiskyDatabaseContext.MyWhiskies.AddAsync(myWhisky);
        await _whiskyDatabaseContext.SaveChangesAsync();

        // Assert
        myWhisky.CreatedDate.ShouldNotBeNull();
    }
    [Fact]
    public async void Save_SetDateUpdatedValue()
    {
        // Arrange
        var myWhisky = new MyWhisky
        {
            Id = 1,
            WhiskyName = "Test",
            ProducerName = "Test"
        };

        // Act
        await _whiskyDatabaseContext.MyWhiskies.AddAsync(myWhisky);
        await _whiskyDatabaseContext.SaveChangesAsync();

        // Assert
        myWhisky.UpdatedDate.ShouldNotBeNull();
    }
}
