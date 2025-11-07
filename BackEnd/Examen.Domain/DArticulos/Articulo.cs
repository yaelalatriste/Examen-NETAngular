using System;
using System.Collections.Generic;

namespace Examen.Domain.DArticulos;

public class Articulo
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Descripcion { get; set; } = null!;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public DateTime FechaCreacion { get; set; }
    public Nullable<DateTime> FechaActualizacion { get; set; }
    public Nullable<DateTime> FechaEliminacion { get; set; }
}
