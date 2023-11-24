using Dapper;
using Property.Application.Interface.Interfaces;
using Property.Persistence.Context;
using System.Data;

namespace Property.Persistence.Repositories
{
    /// <summary>
    /// Clase que implementa la interfaz genérica para operaciones de repositorio utilizando Dapper.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad con la que trabaja el repositorio.</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor que recibe la instancia de ApplicationDbContext para operaciones de base de datos.
        /// </summary>
        /// <param name="context">Instancia de ApplicationDbContext.</param>
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para obtener todos los registros de una entidad mediante un procedimiento almacenado.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        public async Task<IEnumerable<T>> GetAllAsync(string storedProcedure)
        {
            using var conecction = _context.CreateConnection;
            return await conecction.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Método para obtener un registro de una entidad por su identificador mediante un procedimiento almacenado.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameter">Parámetro de búsqueda.</param>
        public async Task<T> GetByIdAsync(string storedProcedure, object parameter)
        {
            using var conecction = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await conecction.QuerySingleOrDefaultAsync<T>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Método para ejecutar un procedimiento almacenado que puede afectar registros en la base de datos.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameters">Parámetros para la ejecución.</param>
        public async Task<bool> ExecAsync(string storedProcedure, object parameters)
        {
            using var conecction = _context.CreateConnection;
            var objParam = new DynamicParameters(parameters);
            var recordAffected = await conecction.ExecuteAsync(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return recordAffected>0;
        }
        
    }
}
