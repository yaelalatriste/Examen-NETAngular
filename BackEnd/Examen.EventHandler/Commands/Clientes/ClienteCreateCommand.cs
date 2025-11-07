using Examen.Domain.DClientes;
using MediatR;

namespace Examen.EventHandler.Commands.Clientes;

public class ClienteCreateCommand : IRequest<Cliente>
{
    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}
