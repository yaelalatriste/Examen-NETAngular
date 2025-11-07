using Examen.Domain.DArticulos;
using Examen.Domain.DClientes;
using MediatR;
using System;
using System.Collections.Generic;

namespace Examen.EventHandler.Commands.Clientes;

public class ClienteArticuloCreateCommand : IRequest<ClienteArticulo>
{
    public int ClienteId { get; set; }

    public int ArticuloId { get; set; }

    public DateTime Fecha { get; set; }
}
