using Examen.Data;
using Examen.Domain.DArticulos;
using Examen.EventHandler.Commands.Articulos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Examen.EventHandler.Handlers.Articulos
{
    public class ArticuloUpdateEventHandler : IRequestHandler<ArticuloUpdateCommand, Articulo>
    {
        private readonly ExamenApplicationContext _context;

        public ArticuloUpdateEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Articulo> Handle(ArticuloUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DateTime fechaCreacion = DateTime.Now;
                var articulo = await _context.Articulos.Where(a => a.Id == request.Id).FirstAsync();

                articulo.Codigo = request.Codigo;
                articulo.Precio = request.Precio;
                articulo.Descripcion = request.Descripcion;
                articulo.Stock = request.Stock;
                articulo.FechaActualizacion = fechaCreacion;

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
