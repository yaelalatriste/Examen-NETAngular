using Examen.Domain.DClientes;
using MediatR;

namespace Examen.EventHandler.Commands.Clientes;

public class ClienteUpdateCommand : IRequest<Cliente>
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}
