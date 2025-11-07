using Examen.Domain.DArticulos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Examen.EventHandler.Commands.Articulos;

public class ArticuloCreateCommand : IRequest<Articulo>
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }
}
