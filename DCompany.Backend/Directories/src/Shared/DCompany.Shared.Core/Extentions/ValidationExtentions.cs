using DCompany.Shared.SharedKernel;
using FluentValidation.Results;

namespace DCompany.Shared.Core.Extentions;

public static class ValidationExtentions
{
    public static ErrorList ToErrorListFromValidationResult(this ValidationResult validationResult)
    {
        List<ValidationFailure> validationErrors = validationResult.Errors;

        IEnumerable<Error> errors = from validationError in validationErrors
                                    let serializedErrorAsMessage = validationError.ErrorMessage
                                    let error = Error.Deserialize(serializedErrorAsMessage)
                                    select Error.Validation(error.Code, error.Message, validationError.PropertyName);

        return new ErrorList(errors);
    }

}
