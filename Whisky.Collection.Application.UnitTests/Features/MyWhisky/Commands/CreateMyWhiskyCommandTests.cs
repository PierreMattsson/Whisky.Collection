using AutoMapper;
using Moq;
using Shouldly;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Application.Features.MyWhisky.Commands.CreateMyWhisky;
using Whisky.Collection.Application.MappingProfiles;
using Whisky.Collection.Application.UnitTests.Mocks;

namespace Whisky.Collection.Application.UnitTests.Features.MyWhisky.Commands;

public class CreateMyWhiskyCommandTests
{
    private readonly IMapper _mapper;
    private Mock<IMyWhiskyRepository> _mockRepo;

    public CreateMyWhiskyCommandTests()
    {
        _mockRepo = MockMyWhiskyRepository.GetMockMyWhiskyRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MyWhiskyProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidMyWhisky()
    {
        var handler = new CreateMyWhiskyCommandHandler(_mapper, _mockRepo.Object);

        await handler.Handle(new CreateMyWhiskyCommand()
        {
            ProducerName = "Macallan1",
            WhiskyName = "Double Cask",
            WhiskyYearStatement = 12,
            BottleDescription = "Highland Single Malt Scotch Whisky",
            AlkoholProcent = 40,
            BottleContentMilliliter = 700,
        }, CancellationToken.None);

        var myWhiskies = await _mockRepo.Object.GetAsync();
        //myWhiskies.Count.ShouldBe(4);
    }
}
