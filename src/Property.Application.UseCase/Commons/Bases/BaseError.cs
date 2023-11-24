namespace Property.Application.UseCase.Commons.Bases
{
    /// <summary>
    /// Clase base para representar un error.
    /// Contiene el nombre de la propiedad y el mensaje de error asociado.
    /// </summary>
    public class BaseError
    {
        /// <summary>
        /// Nombre de la propiedad donde ocurrió el error.
        /// </summary>
        public string? PropertyName { get; set; }

        /// <summary>
        /// Mensaje de error asociado.
        /// </summary>
        public string? ErrorMessage { get; set;}
    }
}
