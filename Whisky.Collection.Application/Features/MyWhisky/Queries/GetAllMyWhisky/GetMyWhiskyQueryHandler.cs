using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetAllMyWhisky;

public class GetMyWhiskyQueryHandler : IRequestHandler<GetMyWhiskyQuery, List<MyWhiskyDTO>>
{
    private readonly IMapper _mapper;
    private readonly IWhiskyRepository _whiskyRepository;

    public GetMyWhiskyQueryHandler(IMapper mapper, IWhiskyRepository whiskyRepository)
    {
        _mapper = mapper;
        _whiskyRepository = whiskyRepository;
    }
    public async Task<List<MyWhiskyDTO>> Handle(GetMyWhiskyQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var myWhisky = await _whiskyRepository.GetAsync();

        // Convert data objects to DTO objects'
        var data = _mapper.Map<List<MyWhiskyDTO>>(myWhisky);

        // Return list of DTO objec
        return data;
    }
}
