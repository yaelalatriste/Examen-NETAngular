using Examen.Data;
using Examen.Domain.DTiendas;
using Examen.EventHandler.Commands.Tiendas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examen.EventHandler.Handlers.Tiendas
{
    public class TiendaUpdateEventHandler : IRequestHandler<TiendaUpdateCommand, Tienda>
    {
        private readonly ExamenApplicationContext _context;

        public TiendaUpdateEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tienda> Handle(TiendaUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tienda = await _context.Tiendas.Where(c => c.Id == request.Id).FirstAsync();

                tienda.Sucursal = request.Sucursal;
                tienda.Direccion = request.Direccion;
                tienda.FechaActualizacion = DateTime.Now;
                
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
