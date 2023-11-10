using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyDetails;

public class GetMyWhiskyDetailsQueryHandler : IRequestHandler<GetMyWhiskyDetailsQuery, MyWhiskyDetailsDTO>
{
    private readonly IMapper _mapper;
    private readonly IMyWhiskyRepository _myWhiskyRepository;

    public GetMyWhiskyDetailsQueryHandler(
        IMapper mapper,
        IMyWhiskyRepository myWhiskyRepository)
    {
        _mapper = mapper;
        _myWhiskyRepository = myWhiskyRepository;
    }

    public async Task<MyWhiskyDetailsDTO> Handle(
        GetMyWhiskyDetailsQuery request,
        CancellationToken cancellationToken)
    {
        // Query the database
        var myWhisky = await _myWhiskyRepository.GetByIdAsync(request.Id);

        // Convert data objects to DTO objects'
        var data = _mapper.Map<MyWhiskyDetailsDTO>(myWhisky);

        // Return list of DTO objec
        return data;
    }
}
