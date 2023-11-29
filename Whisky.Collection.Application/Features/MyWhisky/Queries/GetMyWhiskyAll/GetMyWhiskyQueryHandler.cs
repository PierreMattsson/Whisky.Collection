using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Logging;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyAll;

public class GetMyWhiskyQueryHandler : IRequestHandler<GetMyWhiskyQuery, List<MyWhiskyDTO>>
{
    private readonly IMapper _mapper;
    private readonly IMyWhiskyRepository _myWhiskyRepository;
    private readonly IAppLogger<GetMyWhiskyQueryHandler> _logger;

    public GetMyWhiskyQueryHandler(
        IMapper mapper,
        IMyWhiskyRepository whiskyRepository,
        IAppLogger<GetMyWhiskyQueryHandler> logger)
    {
        _mapper = mapper;
        _myWhiskyRepository = whiskyRepository;
        _logger = logger;
    }
    public async Task<List<MyWhiskyDTO>> Handle(
        GetMyWhiskyQuery request,
        CancellationToken cancellationToken)
    {
        // Query the database
        var myWhisky = await _myWhiskyRepository.GetAsync();

        // Convert data objects to DTO objects'
        var data = _mapper.Map<List<MyWhiskyDTO>>(myWhisky);

        // Return list of DTO objec
        _logger.LogInformation("Leave types were retrived successfullt");
        return data;
    }
}
