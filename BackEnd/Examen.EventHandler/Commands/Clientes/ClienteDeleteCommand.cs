using Examen.Domain.DClientes;
using MediatR;

namespace Examen.EventHandler.Commands.Clientes;

public class ClienteDeleteCommand : IRequest<Cliente>
{
    public int Id { get; set; }
}
