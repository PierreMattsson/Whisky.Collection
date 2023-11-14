using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Application.Exceptions;

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

        // Verify that record exists
        if (myWhisky == null)
            throw new NotFoundException(nameof(MyWhisky), request.Id);

        // Convert data objects to DTO objects'
        var data = _mapper.Map<MyWhiskyDetailsDTO>(myWhisky);

        // Return list of DTO objec
        return data;
    }
}
