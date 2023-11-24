namespace Property.Application.Dtos.Owner.Response
{
    /// <summary>
    /// DTO para la respuesta de obtención de todos los propietarios.
    /// Contiene información básica de un propietario.
    /// </summary>
    public class GetAllOwnerResponseDto
    {
        /// <summary>
        /// Identificador único del propietario.
        /// </summary>
        public int IdOwner { get; set; }

        /// <summary>
        /// Nombre del propietario.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Dirección del propietario.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// ruta de Foto del propietario.
        /// </summary>
        public string? Photo { get; set; }

        /// <summary>
        /// Fecha de nacimiento del propietario.
        /// </summary>
        public DateTime Birthday { get; set; }

    }
}
