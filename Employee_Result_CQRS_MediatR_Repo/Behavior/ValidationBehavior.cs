using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Employee_Result_CQRS_MediatR_Repo.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> (IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var validationResults =await Task.WhenAll(_validators.Select(v =>v.ValidateAsync(context,cancellationToken)));
            var failures =validationResults.SelectMany(x => x.Errors).Where(x => x is not null).ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
            return await next();

        }
    }
}
