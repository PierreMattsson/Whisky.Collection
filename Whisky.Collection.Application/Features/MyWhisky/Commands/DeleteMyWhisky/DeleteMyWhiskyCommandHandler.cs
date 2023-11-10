using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.DeleteMyWhisky;

public class DeleteMyWhiskyCommandHandler : IRequestHandler<DeleteMyWhiskyCommand, Unit>
{
    private readonly IMyWhiskyRepository _myWhiskyRepository;

    public DeleteMyWhiskyCommandHandler(
        IMyWhiskyRepository myWhiskyRepository)
    {
        _myWhiskyRepository = myWhiskyRepository;
    }
    public async Task<Unit> Handle(DeleteMyWhiskyCommand request, CancellationToken cancellationToken)
    {
        // Retrive domain entity object 
        var myWhiskyToDelete = await _myWhiskyRepository.GetByIdAsync(request.Id);

        // Verify that record exists

        // Remove to database
        await _myWhiskyRepository.DeleteAsync(myWhiskyToDelete);

        // Return record id
        return Unit.Value;
    }
}
