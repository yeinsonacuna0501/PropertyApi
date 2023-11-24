using System;

namespace Property.Domain.Entities
{
    /// <summary>
    /// Clase que representa un seguimiento o traza de una propiedad inmobiliaria.
    /// Contiene propiedades relacionadas con la información del seguimiento.
    /// </summary>
    public class PropertyTrace
    {
        /// <summary>
        /// Identificador único de la traza de propiedad.
        /// </summary>
        public int? IdPropertyTrace { get; set; }

        /// <summary>
        /// Fecha de venta de la propiedad registrada en la traza.
        /// </summary>
        public DateTime? DataSale { get; set; }

        /// <summary>
        /// Nombre asociado a la traza de propiedad.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Valor registrado en la traza de propiedad.
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Impuesto registrado en la traza de propiedad.
        /// </summary>
        public decimal? Tax { get; set; }

        /// <summary>
        /// Identificador de la propiedad asociada a la traza.
        /// </summary>
        public int? IdProperty { get; set; }

        /// <summary>
        /// Propiedad asociada a la traza.
        /// </summary>
        public Property? Property { get; set; }
    }
}
