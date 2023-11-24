namespace Property.Domain.Entities
{
    /// <summary>
    /// Clase que representa la entidad Propietario.
    /// Contiene propiedades relacionadas con la información del propietario.
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Identificador único del propietario.
        /// </summary>
        public int? IdOwner { get; set; }

        /// <summary>
        /// Nombre del propietario.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Dirección del propietario.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Ruta o ubicación de la foto del propietario.
        /// </summary>
        public string? Photo { get; set; }

        /// <summary>
        /// Fecha de nacimiento del propietario.
        /// </summary>
        public DateTime? Birthday {  get; set; }
    }
}
