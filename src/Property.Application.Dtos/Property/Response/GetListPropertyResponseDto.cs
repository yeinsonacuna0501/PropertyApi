using Property.Domain.Entities;

namespace Property.Application.Dtos.Property.Response
{
    /// <summary>
    /// DTO para la respuesta de lista de propiedades.
    /// Contiene información resumida de una propiedad.
    /// </summary>
    public class GetListPropertyResponseDto
    {
        /// <summary>
        /// Identificador único de la propiedad.
        /// </summary>
        public int IdProperty { get; set; }
        
        /// <summary>
        /// Nombre de la propiedad.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Dirección de la propiedad.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Precio de la propiedad.
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Código interno de la propiedad.
        /// </summary>
        public string? CodeInternal { get; set; }

        /// <summary>
        /// Año de construcción de la propiedad.
        /// </summary>
        public int? YearProperty { get; set; }

        /// <summary>
        /// Nombre del propietario de la propiedad.
        /// </summary>
        public string? Owner { get; set; }

        public IEnumerable<GetImagesPropertyResponseDto>? Images { get; set; }

        /// <summary>
        /// Lista de trazas o seguimientos de la propiedad.
        /// </summary>
        public IEnumerable<GetTracesPropertyResponseDto>? Traces { get; set; }
    }
}
