using Examen.EventHandler.Commands.Articulos;
using Examen.EventHandler.Commands.Clientes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Examen.Api.Controllers.Articulos.Commands
{
    [ApiController]
    [Authorize]
    [Route("api/articulos")]
    public class CArticuloController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CArticuloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("createArticulo")]
        [HttpPost]
        public async Task<IActionResult> CreateArticulo([FromBody] ArticuloCreateCommand articulo)
        {
            try
            {
                var create = await _mediator.Send(articulo);
                return Ok(create);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Consumes("multipart/form-data")]
        [Route("updateArticulo")]
        [HttpPut]
        public async Task<IActionResult> UpdateArticulo([FromBody] ArticuloUpdateCommand articulo)
        {
            try
            {
                var update = await _mediator.Send(articulo);
                return Ok(update);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("deleteArticulo/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            try
            {
                var command = new ArticuloDeleteCommand
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
