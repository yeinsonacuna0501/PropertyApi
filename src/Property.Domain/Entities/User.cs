namespace Property.Domain.Entities
{
    /// <summary>
    /// Clase que representa a un usuario en el dominio del negocio.
    /// Contiene propiedades relacionadas con la información del usuario.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int? IdUser { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Rol o función del usuario en el sistema.
        /// </summary>
        public string? Role { get; set; }
    }
}
