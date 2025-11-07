using Examen.Domain.DArticulos;
using Examen.Domain.DTiendas;

namespace Examen.Services.DTOs.Articulos;

public class ArticuloTiendaDto
{
    public int ArticuloId { get; set; }

    public int TiendaId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Articulo Articulo { get; set; } = null!;

    public virtual Tienda Tienda { get; set; } = null!;
}
