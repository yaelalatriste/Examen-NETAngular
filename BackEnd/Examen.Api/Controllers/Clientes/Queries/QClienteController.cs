using Examen.Domain.DArticulos;
using Examen.Services.Queries.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Examen.Api.Controllers.Clientes.Queries
{
    [ApiController]
    [Authorize]
    [Route("api/clientes")]
    public class QClienteController : ControllerBase
    {
        private readonly IClienteQueryService _clientes;

        public QClienteController(IClienteQueryService clientes)
        {
            _clientes = clientes;
        }

        [HttpGet]
        [Route("getAllClientes")]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var clientes = await _clientes.GetClientes();
                return Ok(clientes);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet]
        [Route("getClienteById/{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            try
            {
                var tienda = await _clientes.GetClienteById(id);
                return Ok(tienda);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
