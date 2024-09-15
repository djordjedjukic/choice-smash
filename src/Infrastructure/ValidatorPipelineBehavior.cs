using FluentValidation;
using MediatR;
using ValidationException = ChoiceSmash.Infrastructure.Exceptions.ValidationException;

namespace ChoiceSmash.Infrastructure
{
    internal class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }


        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return next();

            // invoke the validators
            var failures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .ToArray();

            if (failures.Any())
                throw new ValidationException(
                    failures.Select(x => x.ErrorMessage));

            return next();
        }
    }
}