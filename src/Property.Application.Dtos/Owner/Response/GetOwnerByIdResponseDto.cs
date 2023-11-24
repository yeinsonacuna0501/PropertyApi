using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Dtos.Owner.Response
{
    /// <summary>
    /// DTO para la respuesta de obtención de un propietario por su ID.
    /// Contiene información básica de un propietario.
    /// </summary>
    public class GetOwnerByIdResponseDto
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
        /// Foto del propietario en formato de bytes.
        /// </summary>
        public string? Photo { get; set; }

        /// <summary>
        /// Fecha de nacimiento del propietario.
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
