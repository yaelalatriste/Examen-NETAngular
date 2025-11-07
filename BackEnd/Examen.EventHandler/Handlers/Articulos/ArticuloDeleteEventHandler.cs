using Examen.Data;
using Examen.Domain.DArticulos;
using Examen.EventHandler.Commands.Articulos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Examen.EventHandler.Handlers.Articulos
{
    public class ArticuloDeleteEventHandler : IRequestHandler<ArticuloDeleteCommand, Articulo>
    {
        private readonly ExamenApplicationContext _context;

        public ArticuloDeleteEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Articulo> Handle(ArticuloDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var articulo = await _context.Articulos.Where(a => a.Id == request.Id).FirstAsync();

                articulo.FechaEliminacion = DateTime.Now;

                await _context.SaveChangesAsync();

                return articulo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
