using FluentValidation;
using Whisky.Collection.Application.Contracts.Persistence;

namespace Whisky.Collection.Application.Features.MyWhisky.Commands.UpdateMyWhisky;

public class UpdateMyWhiskyCommandValidator : AbstractValidator<UpdateMyWhiskyCommand>
{
    private readonly IMyWhiskyRepository _myWhiskyRepository;

    public UpdateMyWhiskyCommandValidator(IMyWhiskyRepository myWhiskyRepository)
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

        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(MyWhiskyMustExist);
    }

    private async Task<bool> MyWhiskyMustExist(int id, CancellationToken token)
    {
        var myWhisky = await _myWhiskyRepository.GetByIdAsync(id);
        return myWhisky != null;
    }
}
