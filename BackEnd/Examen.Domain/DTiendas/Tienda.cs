using System;
using System.Collections.Generic;

namespace Examen.Domain.DTiendas;

public class Tienda
{
    public int Id { get; set; }
    public string Sucursal { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public DateTime FechaCreacion { get; set; }
    public Nullable<DateTime> FechaActualizacion { get; set; }
    public Nullable<DateTime> FechaEliminacion { get; set; }
}
