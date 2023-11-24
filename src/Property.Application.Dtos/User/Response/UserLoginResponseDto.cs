namespace Property.Application.Dtos.User.Response
{
    /// <summary>
    /// DTO para la respuesta del inicio de sesión de usuario.
    /// Contiene información sobre el rol del usuario y el token de acceso.
    /// </summary>
    public class UserLoginResponseDto
    {

        /// <summary>
        /// Rol del usuario.
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Token de acceso generado para el usuario.
        /// </summary>
        public string Token { get; set; }
    }
}
