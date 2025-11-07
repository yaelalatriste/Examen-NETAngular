using Examen.Data;
using Examen.Domain.DArticulos;
using Examen.EventHandler.Commands.Articulos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Examen.EventHandler.Handlers.Articulos
{
    public class ArticuloCreateEventHandler : IRequestHandler<ArticuloCreateCommand, Articulo>
    {
        private readonly ExamenApplicationContext _context;

        public ArticuloCreateEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Articulo> Handle(ArticuloCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DateTime fechaCreacion = DateTime.Now;

                var articulo = new Articulo
                {
                    Codigo = request.Codigo,
                    Precio = request.Precio,
                    Descripcion = request.Descripcion,
                    Stock = request.Stock,
                    FechaCreacion = fechaCreacion
                };

                await _context.AddAsync(articulo);
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
