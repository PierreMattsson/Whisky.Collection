using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.UpdateMyWhisky
{
    public class UpdateMyWhiskyCommandHandler : IRequestHandler<UpdateMyWhiskyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMyWhiskyRepository _myWhiskyRepository;

        public UpdateMyWhiskyCommandHandler(
            IMapper mapper, 
            IMyWhiskyRepository myWhiskyRepository)
        {
            _mapper = mapper;
            _myWhiskyRepository = myWhiskyRepository;
        }
        public async Task<Unit> Handle(UpdateMyWhiskyCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data

            // Convert to domain entity object 
            var myWhiskyToUpdate = _mapper.Map<Domain.MyWhisky>(request);

            // Add to database
            await _myWhiskyRepository.UpdateAsync(myWhiskyToUpdate);

            // Return Unit value
            return Unit.Value;
        }
    }
}
