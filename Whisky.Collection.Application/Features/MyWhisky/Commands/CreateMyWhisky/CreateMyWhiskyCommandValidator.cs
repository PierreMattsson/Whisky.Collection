using FluentValidation;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.CreateMyWhisky;

public class CreateMyWhiskyCommandValidator : AbstractValidator<CreateMyWhiskyCommand>
{
    private readonly IMyWhiskyRepository _myWhiskyRepository;

    public CreateMyWhiskyCommandValidator(IMyWhiskyRepository myWhiskyRepository)
    {
        _myWhiskyRepository = myWhiskyRepository;

        RuleFor(p => p.ProducerName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(p => p.WhiskyName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(p => p.WhiskyYearStatement)
            .NotNull();

        RuleFor(p => p.BottleContentMilliliter)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(p => p.AlkoholProcent)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(p => p.BottleDescription)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(q => q)
            .MustAsync(IsMyWhiskyUnique)
            .WithMessage("This Whisky already exists");
    }

    private Task<bool> IsMyWhiskyUnique(CreateMyWhiskyCommand command, CancellationToken token)
    {
        return _myWhiskyRepository.IsMyWhiskyUnique(command.ProducerName, command.WhiskyName, command.WhiskyYearStatement);
    }
}
