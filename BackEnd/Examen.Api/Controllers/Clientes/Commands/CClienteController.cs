using Examen.Domain.DArticulos;
using Examen.EventHandler.Commands.Clientes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Examen.Api.Controllers.Clientes.Commands
{
    [ApiController]
    [Authorize]
    [Route("api/clientes")]
    public class CClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("createCliente")]
        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] ClienteCreateCommand tienda)
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

        [Route("realizarCompra")]
        [HttpPost]
        public async Task<IActionResult> CreateClienteArticulo([FromBody] ClienteArticuloCreateCommand carrito)
        {
            try
            {
                var create = await _mediator.Send(carrito);
                return Ok(create);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("updateCliente")]
        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] ClienteUpdateCommand tienda)
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

        [Route("deleteCliente/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var command = new ClienteDeleteCommand {
                Id = id
            };
            try
            {
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
