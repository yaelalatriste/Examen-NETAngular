using Examen.Data;
using Examen.Services.DTOs.Clientes;
using Examen.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Examen.Services.Queries.Clientes
{
    public interface IClienteQueryService
    {
        Task<List<ClienteDto>> GetClientes();
        Task<ClienteDto> GetClienteById(int id);
    }

    public class ClienteQueryService : IClienteQueryService
    {
        private readonly ExamenApplicationContext _context;

        public ClienteQueryService(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteDto>> GetClientes()
        {
            var clientes = await _context.Clientes.Where(c => !c.FechaEliminacion.HasValue).ToListAsync();

            return clientes != null ? clientes.MapTo<List<ClienteDto>>() : new List<ClienteDto>();
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.Where(c => c.Id == id).FirstAsync();

            return cliente != null ? cliente.MapTo<ClienteDto>() : new ClienteDto();
        }
    }
}
