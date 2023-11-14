using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Application.Exceptions;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.DeleteMyWhisky;

public class DeleteMyWhiskyCommandHandler : IRequestHandler<DeleteMyWhiskyCommand, Unit>
{
    private readonly IMyWhiskyRepository _myWhiskyRepository;

    public DeleteMyWhiskyCommandHandler(
        IMyWhiskyRepository myWhiskyRepository)
    {
        _myWhiskyRepository = myWhiskyRepository;
    }
    public async Task<Unit> Handle(
        DeleteMyWhiskyCommand request, 
        CancellationToken cancellationToken)
    {
        // Retrive domain entity object 
        var myWhiskyToDelete = await _myWhiskyRepository.GetByIdAsync(request.Id);

        // Verify that record exists
        if (myWhiskyToDelete == null)
            throw new NotFoundException(nameof(MyWhisky), request.Id);

        // Remove to database
        await _myWhiskyRepository.DeleteAsync(myWhiskyToDelete);

        // Return record id
        return Unit.Value;
    }
}
