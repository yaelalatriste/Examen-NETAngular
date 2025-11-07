using Examen.Domain.DArticulos;
using MediatR;

namespace Examen.EventHandler.Commands.Articulos;

public class ArticuloDeleteCommand : IRequest<Articulo>
{
    public int Id { get; set; }
    public Nullable<DateTime> FechaEliminacion { get; set; }

}
