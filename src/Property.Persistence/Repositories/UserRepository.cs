using Dapper;
using Property.Application.Dtos.User.Response;
using Property.Application.Interface.Interfaces;
using Property.Domain.Entities;
using Property.Persistence.Context;
using System.Data;

namespace Property.Persistence.Repositories
{
    /// <summary>
    /// Clase que implementa operaciones específicas de repositorio para la entidad de usuario utilizando Dapper.
    /// </summary>
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;


        /// <summary>
        /// Constructor que recibe la instancia de ApplicationDbContext para operaciones de base de datos.
        /// </summary>
        /// <param name="context">Instancia de ApplicationDbContext.</param>
        public UserRepository(ApplicationDbContext context) : base(context)
        {

            _context = context;
        }

        /// <summary>
        /// Método para realizar el inicio de sesión de un usuario utilizando un procedimiento almacenado y parámetros específicos.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameter">Parámetro de inicio de sesión.</param>
        public async Task<UserLoginResponseDto> Login(string storedProcedure, object parameter)
        {
            using var conecction = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await conecction.QuerySingleOrDefaultAsync<UserLoginResponseDto>(storedProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        } 

        
    }
}
