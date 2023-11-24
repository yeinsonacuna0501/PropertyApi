using Property.Application.UseCase.Commons.Bases;
using Property.Application.UseCase.Commons.Exceptions;
using Property.Utilities.Constants;
using System.Text.Json;

namespace Property.Api.Extensions.Middleware
{
    /// <summary>
    /// Middleware encargado de la validación de excepciones.
    /// </summary>
    public class ValidateMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor del middleware de validación.
        /// </summary>
        /// <param name="next">Delegado de solicitud siguiente en la canalización.</param>
        public ValidateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Método que realiza la invocación del middleware.
        /// </summary>
        /// <param name="context">Contexto HTTP de la solicitud.</param>
        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = GlobalMessages.MESSAGE_VALIDATE,
                    Errors = ex.Errors
                });
            }
        }
    }
}
