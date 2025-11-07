using Examen.EventHandler.Commands.Tiendas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Examen.Api.Controllers.Tiendas.Commands
{
    [ApiController]
    [Authorize]
    [Route("api/tiendas")]
    public class CTiendaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CTiendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("createTienda")]
        [HttpPost]
        public async Task<IActionResult> CreateTienda([FromBody] TiendaCreateCommand tienda)
        {
            try
            {
                var create = await _mediator.Send(tienda);
                return Ok(create);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("updateTienda")]
        [HttpPut]
        public async Task<IActionResult> UpdateTienda([FromBody] TiendaUpdateCommand tienda)
        {
            try
            {
                var update = await _mediator.Send(tienda);
                return Ok(update);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("deleteTienda/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTienda(int id)
        {
            try
            {
                var command = new TiendaDeleteCommand
                {
                    Id = id
                };
                var delete = await _mediator.Send(command);
                return Ok(delete);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
