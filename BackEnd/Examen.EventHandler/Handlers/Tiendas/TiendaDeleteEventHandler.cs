using Examen.Data;
using Examen.Domain.DTiendas;
using Examen.EventHandler.Commands.Tiendas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examen.EventHandler.Handlers.Tiendas
{
    public class TiendaDeleteEventHandler : IRequestHandler<TiendaDeleteCommand, Tienda>
    {
        private readonly ExamenApplicationContext _context;

        public TiendaDeleteEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tienda> Handle(TiendaDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tienda = await _context.Tiendas.Where(c => c.Id == request.Id).FirstAsync();
                tienda.FechaEliminacion = DateTime.Now;
                
                await _context.SaveChangesAsync();

                return tienda;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
