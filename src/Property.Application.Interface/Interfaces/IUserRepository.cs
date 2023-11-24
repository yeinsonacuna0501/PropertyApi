using Property.Application.Dtos.User.Response;
using Property.Domain.Entities;

namespace Property.Application.Interface.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de usuarios.
    /// </summary>
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Realiza el proceso de inicio de sesión de un usuario.
        /// </summary>
        /// <param name="storedProcedure">Nombre del procedimiento almacenado.</param>
        /// <param name="parameter">Parámetros para el inicio de sesión.</param>
        /// <returns>La respuesta del inicio de sesión del usuario.</returns>
        Task<UserLoginResponseDto> Login(string storedProcedure, object parameter);
    }
}
