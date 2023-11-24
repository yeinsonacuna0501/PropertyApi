namespace Property.Application.Dtos.Property.Response
{
    /// <summary>
    /// DTO para la respuesta de las imagenes relaacionadas a una propiedad.
    /// Contiene información de una imagen de la propiedad.
    /// </summary>
    public class GetImagesPropertyResponseDto
    {
        /// <summary>
        /// Identificador único de la imagen de la propiedad.
        /// </summary>
        public int? IdPropertyImage { get; set; }

        /// <summary>
        /// Ruta o nombre del archivo de la imagen de la propiedad.
        /// </summary>
        public string? FilePropertyImage { get; set; }

        /// <summary>
        /// Estado de habilitación de la imagen.
        /// </summary>
        public bool? Enabled { get; set; }
    }
}
