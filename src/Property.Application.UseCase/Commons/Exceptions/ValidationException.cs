using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.Commons.Exceptions
{
    /// <summary>
    /// Excepción personalizada para errores de validación.
    /// Contiene una lista de errores BaseError.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Lista de errores de validación.
        /// </summary>
        public IEnumerable<BaseError> Errors { get; set; }

        /// <summary>
        /// Constructor 
        /// Inicializa una nueva instancia de ValidationException.
        /// </summary>
        public ValidationException() : base()
        {
            Errors = new List<BaseError>();
        }

        /// <summary>
        /// Constructor con parámetros.
        /// Inicializa una nueva instancia de ValidationException con una lista de errores.
        /// </summary>
        /// <param name="errors">Lista de errores de validación.</param>
        public ValidationException(IEnumerable<BaseError> errors) : this()
        {
            Errors = errors;
        }
    }
}
