using MediatR;
using Microsoft.AspNetCore.Mvc;
using Property.Application.UseCase.UseCases.User.Queries.GetLoginUser;

namespace Property.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Realiza la autenticación de un usuario.
        /// </summary>
        /// <remarks>
        /// Proporciona el usuario y la contraseña para autenticar al usuario en el sistema.
        /// </remarks>
        /// <param name="login">Datos de inicio de sesión del usuario.</param>
        /// <response code="201">Autenticación exitosa.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Login([FromBody] GetUserLoginQuery login)
        {
            var response = await _mediator.Send(login);
            return Ok(response);
        }
    }
}
