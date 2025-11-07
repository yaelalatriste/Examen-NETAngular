using Examen.Domain.DArticulos;
using Examen.Services.Queries.Articulos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Examen.Api.Controllers.Articulos.Queries
{
    [ApiController]
    [Authorize]
    [Route("api/articulos")]
    public class QArticuloController : ControllerBase
    {
        private readonly IArticuloQueryService _articulos;

        public QArticuloController(IArticuloQueryService clientes)
        {
            _articulos = clientes;
        }

        [HttpGet]
        [Route("getAllArticulos")]
        public async Task<IActionResult> GetAllArticulos()
        {
            try
            {
                var clientes = await _articulos.GetArticulos();
                return Ok(clientes);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getArticuloById/{id}")]
        public async Task<IActionResult> GetArticuloById(int id)
        {
            try
            {
                var tienda = await _articulos.GetArticuloById(id);
                return Ok(tienda);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
