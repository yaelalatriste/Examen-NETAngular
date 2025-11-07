using Examen.Domain.DTiendas;
using MediatR;

namespace Examen.EventHandler.Commands.Tiendas;

public class TiendaUpdateCommand : IRequest<Tienda>
{
    public int Id { get; set; }

    public string Sucursal { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}
