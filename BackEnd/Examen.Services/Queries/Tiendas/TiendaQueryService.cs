using Examen.Data;
using Examen.Services.DTOs.Tiendas;
using Examen.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Examen.Services.Queries.Tiendas
{
    public interface ITiendaQueryService
    {
        Task<List<TiendaDto>> GetTiendas();
        Task<TiendaDto> GetTiendaById(int id);
    }

    public class TiendaQueryService : ITiendaQueryService
    {
        private readonly ExamenApplicationContext _context;

        public TiendaQueryService(ExamenApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<TiendaDto>> GetTiendas()
        {
            var Tiendas = await _context.Tiendas.Where(c => !c.FechaEliminacion.HasValue).ToListAsync();

            return Tiendas != null ? Tiendas.MapTo<List<TiendaDto>>() : new List<TiendaDto>();
        }

        public async Task<TiendaDto> GetTiendaById(int id)
        {
            var Tienda = await _context.Tiendas.Where(c => c.Id == id).FirstAsync();

            return Tienda != null ? Tienda.MapTo<TiendaDto>() : new TiendaDto();
        }
    }
}
