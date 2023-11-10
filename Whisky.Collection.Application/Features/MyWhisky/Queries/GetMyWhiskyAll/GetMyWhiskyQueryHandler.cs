using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyAll;

public class GetMyWhiskyQueryHandler : IRequestHandler<GetMyWhiskyQuery, List<MyWhiskyDTO>>
{
    private readonly IMapper _mapper;
    private readonly IMyWhiskyRepository _myWhiskyRepository;

    public GetMyWhiskyQueryHandler(
        IMapper mapper,
        IMyWhiskyRepository whiskyRepository)
    {
        _mapper = mapper;
        _myWhiskyRepository = whiskyRepository;
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
        return data;
    }
}
