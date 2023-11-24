namespace Property.Domain.Entities
{
    /// <summary>
    /// Clase que representa una imagen asociada a una propiedad inmobiliaria.
    /// Contiene propiedades relacionadas con la información de la imagen.
    /// </summary>
    public class PropertyImage
    {
        /// <summary>
        /// Identificador único de la imagen de la propiedad.
        /// </summary>
        public int? IdPropertyImage { get; set; }

        /// <summary>
        /// Identificador de la propiedad asociada a la imagen.
        /// </summary>
        public int? IdProperty { get; set; }

        /// <summary>
        /// Ruta o nombre del archivo de la imagen de la propiedad.
        /// </summary>
        public string? FilePropertyImage { get; set; }

        /// <summary>
        /// Estado de habilitación de la imagen.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Propiedad asociada a la imagen.
        /// </summary>
        public Property? Property { get; set; }
    }
}
