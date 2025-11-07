using Examen.Domain.DArticulos;
using System;
using System.Collections.Generic;

namespace Examen.Services.DTOs.Clientes;

public class ClienteArticuloDto
{
    public int ClienteId { get; set; }

    public int ArticuloId { get; set; }

    public DateTime Fecha { get; set; }
    public virtual Articulo Articulo { get; set; } = null!;

    public virtual ClienteDto Cliente { get; set; } = null!;
}
