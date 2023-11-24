using System.Collections.Generic;

namespace Property.Domain.Entities
{
    /// <summary>
    /// Clase que representa la entidad Propiedad inmobiliaria.
    /// Contiene propiedades relacionadas con la información de la propiedad.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Identificador único de la propiedad.
        /// </summary>
        public int? IdProperty { get; set; }

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
        /// Identificador del propietario de la propiedad.
        /// </summary>
        public int? IdOwner { get; set; }

        /// <summary>
        /// Propietario asociado a la propiedad.
        /// </summary>
        public Owner? Owner { get; set; }

        /// <summary>
        /// Lista de imágenes asociadas a la propiedad.
        /// </summary>
        public List<PropertyImage>? Images { get; set; }

        /// <summary>
        /// Lista de trazas o seguimientos de la propiedad.
        /// </summary>
        public List<PropertyTrace>? Traces { get; set; }
    }
}
