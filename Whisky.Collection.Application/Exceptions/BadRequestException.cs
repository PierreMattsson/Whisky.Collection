using FluentValidation.Results;

namespace Whisky.Collection.Application.Exceptions;

public class BadRequestException : Exception
{
    // Here we convert to a dictionary so for all Errors we have the name of the exception,
    // then we get an array of errors in the secound field.
    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        {
            ValidationErrors = validationResult.ToDictionary();
        }
    }

    public IDictionary<string, string[]> ValidationErrors { get; set; }
}
