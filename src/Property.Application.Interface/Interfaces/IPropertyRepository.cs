using Property.Application.Dtos.Property.Response;
using Entity = Property.Domain.Entities;

namespace Property.Application.Interface.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de propiedades.
    /// </summary>
    public interface IPropertyRepository : IGenericRepository<Entity.Property>
    {
        /// <summary>
        /// Obtiene una lista filtrada de propiedades de forma asincrónica.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameter">Parámetros para filtrar las propiedades.</param>
        /// <returns>Una colección de propiedades filtradas.</returns>
        Task<IEnumerable<GetListPropertyResponseDto>> GetFilterProperty(string storedProcedure, object parameter);
        Task<IEnumerable<GetImagesPropertyResponseDto>> GetImagesForProperty(string storedProcedure, object parameter);
        Task<IEnumerable<GetTracesPropertyResponseDto>> GetTracesForProperty(string storedProcedure, object parameter);

    }
}
