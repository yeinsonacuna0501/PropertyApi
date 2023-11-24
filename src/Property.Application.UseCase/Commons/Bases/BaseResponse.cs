namespace Property.Application.UseCase.Commons.Bases
{
    /// <summary>
    /// Clase base para representar una respuesta genérica.
    /// Contiene información sobre el éxito de la operación, datos relacionados,
    /// mensajes y posibles errores.
    /// </summary>
    /// <typeparam name="T">Tipo de datos asociados a la respuesta.</typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Datos relacionados a la respuesta.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Mensaje asociado a la respuesta.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Posibles errores asociados a la respuesta.
        /// </summary>
        public IEnumerable<BaseError>? Errors { get; set; }
    }
}
