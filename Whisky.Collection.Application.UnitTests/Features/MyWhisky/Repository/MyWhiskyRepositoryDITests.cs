using MyWhiskyDomain = Whisky.Collection.Domain.MyWhisky;
using Moq;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Application.UnitTests.Mocks;

namespace Whisky.Collection.Application.UnitTests.Features.MyWhisky.Repository;

public class MyWhiskyRepositoryDITests
{
    private readonly Mock<IMyWhiskyRepository> _mockMyWhiskyRepository;

    public MyWhiskyRepositoryDITests()
    {
        _mockMyWhiskyRepository = MockMyWhiskyRepository.GetMockMyWhiskyRepository();
    }

    [Fact]
    public async Task IsMyWhiskyUniqueReturnsTrue()
    {
        // Arrange
        var uniqueWhisky = new MyWhiskyDomain
        {
            Id = 4,
            WhiskyName = "UniqueTest",
            ProducerName = "UniqueTest",
            WhiskyYearStatement = 12
        };

        // Act
        var isUnique = await _mockMyWhiskyRepository.Object.IsMyWhiskyUnique(
            uniqueWhisky.ProducerName,
            uniqueWhisky.WhiskyName,
            uniqueWhisky.WhiskyYearStatement);

        // Assert
        Assert.True(isUnique);
    }

    [Fact]
    public async Task IsMyWhiskyUniqueReturnsFalse()
    {
        // Arrange
        var uniqueWhisky = new MyWhiskyDomain
        {
            Id = 1,
            WhiskyName = "Test1",
            ProducerName = "Test1",
            WhiskyYearStatement = 12
        };

        // Act
        var isUnique = await _mockMyWhiskyRepository.Object.IsMyWhiskyUnique(
            uniqueWhisky.ProducerName,
            uniqueWhisky.WhiskyName,
            uniqueWhisky.WhiskyYearStatement);

        // Assert
        Assert.False(isUnique);
    }
}
