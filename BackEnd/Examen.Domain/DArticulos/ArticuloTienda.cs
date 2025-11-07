using Examen.Domain.DTiendas;
using System;
using System.Collections.Generic;

namespace Examen.Domain.DArticulos;

public class ArticuloTienda
{
    public int ArticuloId { get; set; }

    public int TiendaId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Articulo Articulo { get; set; } = null!;

    public virtual Tienda Tienda { get; set; } = null!;
}
