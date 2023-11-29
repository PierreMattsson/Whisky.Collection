using Moq;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Domain;

namespace Whisky.Collection.Application.UnitTests.Mocks;

public class MockMyWhiskyRepository
{
    public static Mock<IMyWhiskyRepository> GetMyWhiskyMockMyWhiskyRepository()
    {
        var myWhiskys = new List<MyWhisky>
        {
            new() {
                Id = 1,
                WhiskyName = "Test",
                ProducerName = "Test"
            },
            new()
            {
                Id = 2,
                WhiskyName = "Test2",
                ProducerName = "Test2"
            },
            new()
            {
                Id = 3,
                WhiskyName = "Test3",
                ProducerName = "Test3"
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

        return mockRepo;
    }
}
