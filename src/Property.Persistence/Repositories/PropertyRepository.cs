using Dapper;
using Property.Application.Dtos.Property.Response;
using Property.Application.Interface.Interfaces;
using Property.Persistence.Context;
using System.Data;
using Entity = Property.Domain.Entities;

namespace Property.Persistence.Repositories
{
    // <summary>
    /// Clase que implementa operaciones específicas de repositorio para entidad Property utilizando Dapper.
    /// </summary>
    public class PropertyRepository : GenericRepository<Entity.Property>, IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor que recibe la instancia de ApplicationDbContext para operaciones de base de datos.
        /// </summary>
        public PropertyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Método para filtrar propiedades utilizando un procedimiento almacenado y parámetros específicos.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameter">Parámetro de filtro.</param>
        public async Task<IEnumerable<GetListPropertyResponseDto>> GetFilterProperty(string storedProcedure, object parameter)
        {
            using var conecction = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await conecction.QueryAsync<GetListPropertyResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetImagesPropertyResponseDto>> GetImagesForProperty(string storedProcedure, object parameter)
        {
            using var conecction = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await conecction.QueryAsync<GetImagesPropertyResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTracesPropertyResponseDto>> GetTracesForProperty(string storedProcedure, object parameter)
        {
            using var conecction = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await conecction.QueryAsync<GetTracesPropertyResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }
    }
}
