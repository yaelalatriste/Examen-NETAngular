using Examen.Data;
using Examen.Services.DTOs.Articulos;
using Examen.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Examen.Services.Queries.Articulos
{
    public interface IArticuloQueryService
    {
        Task<List<ArticuloDto>> GetArticulos();
        Task<ArticuloDto> GetArticuloById(int id);
    }

    public class ArticuloQueryService : IArticuloQueryService
    {
        private readonly ExamenApplicationContext _context;

        public ArticuloQueryService(ExamenApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<ArticuloDto>> GetArticulos()
        {
            var Articulos = await _context.Articulos.Where(c => !c.FechaEliminacion.HasValue).ToListAsync();

            return Articulos != null ? Articulos.MapTo<List<ArticuloDto>>() : new List<ArticuloDto>();
        }

        public async Task<ArticuloDto> GetArticuloById(int id)
        {
            var Articulo = await _context.Articulos.Where(c => c.Id == id).FirstAsync();

            return Articulo != null ? Articulo.MapTo<ArticuloDto>() : new ArticuloDto();
        }
    }
}
