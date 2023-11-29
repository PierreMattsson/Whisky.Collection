using AutoMapper;
using MediatR;
using Whisky.Collection.Application.Contracts.Logging;
using Whisky.Collection.Application.Contracts.Persistence;
using Whisky.Collection.Application.Exceptions;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.UpdateMyWhisky
{
    public class UpdateMyWhiskyCommandHandler : IRequestHandler<UpdateMyWhiskyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMyWhiskyRepository _myWhiskyRepository;
        private readonly IAppLogger<UpdateMyWhiskyCommandHandler> _logger;

        public UpdateMyWhiskyCommandHandler(
            IMapper mapper, 
            IMyWhiskyRepository myWhiskyRepository,
            IAppLogger<UpdateMyWhiskyCommandHandler> logger)
        {
            _mapper = mapper;
            _myWhiskyRepository = myWhiskyRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(
            UpdateMyWhiskyCommand request, 
            CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdateMyWhiskyCommandValidator(_myWhiskyRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(MyWhisky), request.Id);
                throw new BadRequestException("Invalid Whisky type", validationResult);
            }

            // Convert to domain entity object 
            var myWhiskyToUpdate = _mapper.Map<Domain.MyWhisky>(request);

            // Add to database
            await _myWhiskyRepository.UpdateAsync(myWhiskyToUpdate);

            // Return Unit value
            return Unit.Value;
        }
    }
}
