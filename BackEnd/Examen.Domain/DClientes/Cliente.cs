using System;
using System.Collections.Generic;

namespace Examen.Domain.DClientes;

public partial class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellidos { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public DateTime FechaCreacion { get; set; }
    public Nullable<DateTime> FechaActualizacion { get; set; }
    public Nullable<DateTime> FechaEliminacion { get; set; }
}
