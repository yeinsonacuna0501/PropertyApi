namespace Property.Api.Extensions.Middleware
{
    /// <summary>
    /// Clase  para agregar middleware a la canalización de solicitudes.
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Método de extensión para agregar un middleware de validación a la canalización de solicitudes.
        /// </summary>
        /// <param name="builder">Constructor de aplicaciones web.</param>
        /// <returns>Constructor de aplicaciones web con middleware de validación agregado.</returns>
        public static IApplicationBuilder AddMiddleware(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ValidateMiddleware>();
        }
    }
}
