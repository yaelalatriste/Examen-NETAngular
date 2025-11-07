using Examen.Data;
using Examen.Domain.DClientes;
using Examen.EventHandler.Commands.Clientes;
using MediatR;

namespace Examen.EventHandler.Handlers.Clientes
{
    public class ClienteCreateEventHandler : IRequestHandler<ClienteCreateCommand, Cliente>
    {
        private readonly ExamenApplicationContext _context;

        public ClienteCreateEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Handle(ClienteCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = new Cliente 
                { 
                    Nombre = request.Nombre,
                    Apellidos = request.Apellidos,
                    Direccion = request.Direccion,
                    FechaCreacion = DateTime.Now
                };

                await _context.AddAsync(cliente);
                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
