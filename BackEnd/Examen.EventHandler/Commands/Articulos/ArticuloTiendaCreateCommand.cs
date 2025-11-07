using Examen.Domain.DArticulos;
using MediatR;

namespace Examen.EventHandler.Commands.Articulos;

public class ArticuloTiendaCreateCommand : IRequest<ArticuloTienda>
{
    public int ArticuloId { get; set; }

    public int TiendaId { get; set; }

    public DateTime Fecha { get; set; }

}
