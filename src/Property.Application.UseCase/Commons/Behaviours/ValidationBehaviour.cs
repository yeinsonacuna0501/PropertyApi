using FluentValidation;
using MediatR;
using Property.Application.UseCase.Commons.Bases;
using ValidationException = Property.Application.UseCase.Commons.Exceptions.ValidationException;

namespace Property.Application.UseCase.Commons.Behaviours
{
    /// <summary>
    /// Comportamiento de validación para solicitudes de MediatR.
    /// Valida las solicitudes utilizando validadores FluentValidation y maneja los errores de validación.
    /// </summary>
    /// <typeparam name="TRequest">Tipo de la solicitud.</typeparam>
    /// <typeparam name="TResponse">Tipo de la respuesta.</typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validator.Select(x => x.ValidateAsync(context, cancellationToken)));

                var failures = validationResults
                    .Where(x => x.Errors.Any())
                    .SelectMany(x => x.Errors)
                    .Select(x => new BaseError()
                    {
                        PropertyName = x.PropertyName,
                        ErrorMessage = x.ErrorMessage
                    }).ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
