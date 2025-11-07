using Examen.Data;
using Examen.Domain.DTiendas;
using Examen.EventHandler.Commands.Tiendas;
using MediatR;

namespace Examen.EventHandler.Handlers.Tiendas
{
    public class TiendaCreateEventHandler : IRequestHandler<TiendaCreateCommand, Tienda>
    {
        private readonly ExamenApplicationContext _context;

        public TiendaCreateEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tienda> Handle(TiendaCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tienda = new Tienda 
                { 
                    Sucursal = request.Sucursal,
                    Direccion = request.Direccion,
                    FechaCreacion = DateTime.Now
                };

                await _context.AddAsync(tienda);
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
