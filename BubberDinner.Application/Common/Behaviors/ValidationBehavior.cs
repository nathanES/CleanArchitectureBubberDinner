using BubberDinner.Application.Authentication.Commands.Register;
using BubberDinner.Application.Authentication.Common;
using FluentValidation;

namespace BubberDinner.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null) :
    IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validator is null)
        {
            return await next();
        }
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            return await next();
        }
        var errors = validationResult.Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName, 
                validationFailure.ErrorMessage));
        return (dynamic)errors; //Not a good practice, but it works for now and we have constraints on TResponse
    }
}