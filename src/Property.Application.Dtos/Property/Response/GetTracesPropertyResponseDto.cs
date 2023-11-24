using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Dtos.Property.Response
{
    /// <summary>
    /// DTO para la respuesta de los seguimientos o trazas de una propiedad inmobiliaria.
    /// Contiene propiedades relacionadas con la información del seguimiento.
    /// </summary>
    public class GetTracesPropertyResponseDto
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
    }
}
