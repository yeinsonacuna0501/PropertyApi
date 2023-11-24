using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Property.Application.UseCase.UseCases.Owner.Commands.CreateCommand;
using Property.Application.UseCase.UseCases.Owner.Commands.UpdateCommand;
using Property.Application.UseCase.UseCases.Owner.Queries.GetAllQuery;
using Property.Application.UseCase.UseCases.Owner.Queries.GetByIdQuery;

namespace Property.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _routeServer;

        public OwnerController(IMediator mediator, IConfiguration config)
        {
            _mediator = mediator;
            _routeServer = config.GetSection("Configuration").GetSection("RouteServer").Value;
        }

        /// <summary>
        /// Obtiene una lista de todos los propietarios.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ListOwner()
        {
            var response = await _mediator.Send(new GetAllOwnerQuery());

            return Ok(response);
        }


        /// <summary>
        /// Obtiene información de un propietario por su ID.
        /// </summary>
        /// <param name="ownerId">ID del propietario.</param>
        [HttpGet("{ownerId:int}")]
        public async Task<IActionResult> OwnerById(int ownerId)
        {
            var response = await _mediator.Send(new GetOwnerByIdQuery() { IdOwner = ownerId });

            return Ok(response);
        }


        /// <summary>
        /// Registra un nuevo propietario con foto.
        /// </summary>
        /// <param name="ownerCommand">Datos del propietario y su foto.</param>
        [HttpPost("Register")]
        [DisableRequestSizeLimit,RequestFormLimits(MultipartBodyLengthLimit =int.MaxValue, ValueLengthLimit =int.MaxValue)]
        public async Task<IActionResult> RegisterOwner([FromForm] CreateOwnerPhotoCommand ownerCommand)
        {
            string routeFile = Path.Combine(_routeServer, ownerCommand.Photo.FileName);
            try
            {

                if (!Directory.Exists(routeFile))                        
                {
                    DirectoryInfo di = Directory.CreateDirectory(_routeServer);                           
                }               

                using (FileStream newFile = System.IO.File.Create(routeFile))
                {
                    ownerCommand.Photo.CopyTo(newFile);
                    newFile.Flush();
                }
                CreateOwnerCommand createOwnerCommand = new CreateOwnerCommand
                {
                    Name = ownerCommand.Name,
                    Address = ownerCommand.Address,
                    Photo = routeFile,
                    Birthday = ownerCommand.Birthday

                };
                var response = await _mediator.Send(createOwnerCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        /// Edita un propietario existente con foto.
        /// </summary>
        /// <param name="ownerCommand">Datos del propietario y su foto.</param>
        [HttpPut("Edit")]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue, ValueLengthLimit = int.MaxValue)]
        public async Task<IActionResult> EditOwner([FromForm] UpdateOwnerPhotoCommand ownerCommand)
        {
            string routeFile = Path.Combine(_routeServer, ownerCommand.Photo.FileName);
            try
            {

                if (!Directory.Exists(routeFile))
                {
                    DirectoryInfo di = Directory.CreateDirectory(_routeServer);
                }

                using (FileStream newFile = System.IO.File.Create(routeFile))
                {
                    ownerCommand.Photo.CopyTo(newFile);
                    newFile.Flush();
                }
                UpdateOwnerCommand createOwnerCommand = new UpdateOwnerCommand
                {
                    IdOwner = ownerCommand.IdOwner,
                    Name = ownerCommand.Name,
                    Address = ownerCommand.Address,
                    Photo = routeFile,
                    Birthday = ownerCommand.Birthday

                };
                var response = await _mediator.Send(createOwnerCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
