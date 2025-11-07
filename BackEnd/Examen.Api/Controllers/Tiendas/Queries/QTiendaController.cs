using Examen.Domain.DArticulos;
using Examen.Services.DTOs.Tiendas;
using Examen.Services.Queries.Tiendas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Examen.Api.Controllers.Tiendas.Queries
{
    [ApiController]
    [Authorize]
    [Route("api/tiendas")]
    public class QTiendaController : ControllerBase
    {
        private readonly ITiendaQueryService _tiendas;

        public QTiendaController(ITiendaQueryService tiendas)
        {
            _tiendas = tiendas;
        }

        [HttpGet]
        [Route("getAllTiendas")]
        public async Task<IActionResult> GetAllTiendas()
        {
            try
            {
                var tiendas = await _tiendas.GetTiendas();
                return Ok(tiendas);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpGet]
        [Route("getTiendaById/{id}")]
        public async Task<IActionResult> GetTiendaById(int id)
        {
            try
            {
                var tienda = await _tiendas.GetTiendaById(id);
                return Ok(tienda);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
