using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Property.Application.UseCase.UseCases.Property.Commands.AddImageCommand;
using Property.Application.UseCase.UseCases.Property.Commands.ChangePriceCommand;
using Property.Application.UseCase.UseCases.Property.Commands.CreateCommand;
using Property.Application.UseCase.UseCases.Property.Commands.UpdateCommand;
using Property.Application.UseCase.UseCases.Property.Queries.GetFilterQuery;

namespace Property.Api.Controllers
{
    /// <summary>
    /// API para administrar propiedades.
    /// </summary>

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string? _routeServer;
        /// <summary>
        /// Constructor de la clase PropertyController.
        /// </summary>
        public PropertyController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _routeServer = config.GetSection("Configuration").GetSection("RouteServer").Value;
        }
        /// <summary>
        /// Registra una nueva propiedad.
        /// </summary>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterProperty([FromBody] CreatePropertyCommand propertyCommand)
        {
            var response = await _mediator.Send(propertyCommand);
            return Ok(response);
        }
        /// <summary>
        /// Edita una propiedad existente.
        /// </summary>
        [HttpPut("Edit")]
        public async Task<IActionResult> EditProperty([FromBody] UpdatePropertyCommand propertyCommand)
        {
            var response = await _mediator.Send(propertyCommand);
            return Ok(response);
        }
        /// <summary>
        /// Cambia el precio de una propiedad.
        /// </summary>
        [HttpPut("ChangePrice")]
        public async Task<IActionResult> ChangePriceProperty([FromBody] ChangePricePropertyCommand propertyCommand)
        {
            var response = await _mediator.Send(propertyCommand);
            return Ok(response);
        }

        /// <summary>
        /// Agregar Imagen de una propiedad.
        /// </summary>
        [HttpPut("AddImage")]
        public async Task<IActionResult> AddImageProperty([FromForm] UploadImagePropertyCommand propertyCommand)
        {
            string routeFile = Path.Combine(_routeServer, propertyCommand.FilePropertyImage.FileName);
            try
            {

                if (!Directory.Exists(routeFile))
                {
                    DirectoryInfo di = Directory.CreateDirectory(_routeServer);
                }

                using (FileStream newFile = System.IO.File.Create(routeFile))
                {
                    propertyCommand.FilePropertyImage.CopyTo(newFile);
                    newFile.Flush();
                }
                AddImagePropertyCommand uploadImagePropertyCommand = new AddImagePropertyCommand
                {
                    IdProperty = propertyCommand.IdProperty,
                    FilePropertyImage = routeFile,
                    Enabled = propertyCommand.Enabled,

                };
                var response = await _mediator.Send(uploadImagePropertyCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una lista de propiedades con filtros.
        /// </summary>

        [HttpGet("filter")]
        public async Task<IActionResult> ListPropertyWithFilters(string filter)
        {
            var response = await _mediator.Send(new GetPropertyFilterQuery() { Filter = filter });

            return Ok(response);
        }
    }
}
