using AutoMapper;
using Moq;
using Shouldly;
using Whisky.Collection.Application.Contracts.Logging;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyAll;
using Whisky.Collection.Application.MappingProfiles;
using Whisky.Collection.Application.UnitTests.Mocks;

namespace Whisky.Collection.Application.UnitTests.Features.MyWhisky.Queries;

public class GetMyWhiskyListQueryHandlerTests
{
    private readonly Mock<IMyWhiskyRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLogger<GetMyWhiskyQueryHandler>> _mockAppLogger;

    public GetMyWhiskyListQueryHandlerTests()
    {
        _mockRepo = MockMyWhiskyRepository.GetMockMyWhiskyRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MyWhiskyProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetMyWhiskyQueryHandler>>();
    }

    [Fact]
    public async Task GetMyWhiskyListTest()
    {
        var handler = new GetMyWhiskyQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

        var result = await handler.Handle(new GetMyWhiskyQuery(), CancellationToken.None);

        // This could have been "Assert" but some cases this verion reads better!
        result.ShouldBeOfType<List<MyWhiskyDTO>>();
        result.Count.ShouldBe(3);
    }
}
