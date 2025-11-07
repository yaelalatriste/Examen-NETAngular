using Examen.Domain.DTiendas;
using MediatR;

namespace Examen.EventHandler.Commands.Tiendas;

public class TiendaDeleteCommand : IRequest<Tienda>
{
    public int Id { get; set; }
}
