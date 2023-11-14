using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Application.Exceptions;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.CreateMyWhisky;

public class CreateMyWhiskyCommandHandler : IRequestHandler<CreateMyWhiskyCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IMyWhiskyRepository _myWhiskyRepository;

    public CreateMyWhiskyCommandHandler(
        IMapper mapper, 
        IMyWhiskyRepository myWhiskyRepository)
    {
        _mapper = mapper;
        _myWhiskyRepository = myWhiskyRepository;
    }
    public async Task<int> Handle(
        CreateMyWhiskyCommand request, 
        CancellationToken cancellationToken)
    {
        // Validate incoming data
        var validator = new CreateMyWhiskyCommandValidator(_myWhiskyRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid MyWhisky", validationResult);

        // Convert to domain entity object 
        var myWhiskyToCreate = _mapper.Map<Domain.MyWhisky>(request);

        // Add to database
        await _myWhiskyRepository.CreateAsync(myWhiskyToCreate);

        // Return record id
        return myWhiskyToCreate.Id;
    }
}
