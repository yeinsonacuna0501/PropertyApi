namespace Property.Application.Interface.Interfaces
{
    /// <summary>
    /// Interfaz genérica para operaciones de repositorio.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene todas las entidades de forma asincrónica.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <returns>Una colección de entidades del tipo especificado.</returns>
        Task<IEnumerable<T>> GetAllAsync(string storedProcedure);

        /// <summary>
        /// Obtiene una entidad por su ID de forma asincrónica.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameter">Parámetro para buscar la entidad.</param>
        /// <returns>La entidad del tipo especificado encontrada por su ID.</returns>
        Task<T> GetByIdAsync(string storedProcedure, object parameter);

        /// <summary>
        /// Ejecuta un procedimiento almacenado de forma asincrónica.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameters">Parámetros para ejecutar el procedimiento almacenado.</param>
        /// <returns>True si la ejecución fue exitosa, False si falló.</returns>
        Task<bool> ExecAsync(string storedProcedure, object parameters);
    }
}
