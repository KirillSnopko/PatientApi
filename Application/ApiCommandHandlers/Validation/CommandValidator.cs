using FluentValidation;
using MediatR;


namespace Application.ApiCommandHandlers.Validation;

public sealed class CommandValidator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator> _validators;

    public CommandValidator(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationFailures = _validators
            .Select(validator => validator.Validate(new ValidationContext<TRequest>(request)))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure != null)
            .ToList();

        if (validationFailures.Count == 0)
        {
            return next();
        }

        throw new ArgumentException(string.Concat(validationFailures.Select(x => string.Concat(x.PropertyName, ": ", x.ErrorMessage))));
    }
}
