using Moq;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Domain;

namespace Whisky.Collection.Application.UnitTests.Mocks;

public class MockMyWhiskyRepository
{
    public static Mock<IMyWhiskyRepository> GetMockMyWhiskyRepository()
    {
        var myWhiskys = new List<MyWhisky>
        {
            new() {
                Id = 1,
                WhiskyName = "Test1",
                ProducerName = "Test1",
                WhiskyYearStatement = 12
            },
            new()
            {
                Id = 2,
                WhiskyName = "Test2",
                ProducerName = "Test2",
                WhiskyYearStatement = 12
            },
            new()
            {
                Id = 3,
                WhiskyName = "Test3",
                ProducerName = "Test3",
                WhiskyYearStatement = 12
            }
        };

        // Mock so none of this will be implemented! (Abstraction)
        var mockRepo = new Mock<IMyWhiskyRepository>();

        // While testing it will return our mock
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(myWhiskys);

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<MyWhisky>()))
                .Returns((MyWhisky myWhisky) =>
                {
                    myWhiskys.Add(myWhisky);
                    return Task.CompletedTask;
                });

        mockRepo.Setup(r => r.IsMyWhiskyUnique(
            It.IsAny<string>(), 
            It.IsAny<string>(), 
            It.IsAny<int>()))

            .ReturnsAsync((
                string producerName, 
                string whiskyName, 
                int whiskyYearStatement) =>
            {
                return !myWhiskys.Any(q => 
                    q.ProducerName == producerName && 
                    q.WhiskyName == whiskyName &&
                    q.WhiskyYearStatement == whiskyYearStatement);
            });

        return mockRepo;
    }
}
