using Examen.Domain.DTiendas;
using MediatR;

namespace Examen.EventHandler.Commands.Tiendas;

public class TiendaCreateCommand : IRequest<Tienda>
{
    public string Sucursal { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}
