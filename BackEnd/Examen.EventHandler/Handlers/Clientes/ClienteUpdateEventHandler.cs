using Examen.Data;
using Examen.Domain.DClientes;
using Examen.EventHandler.Commands.Clientes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examen.EventHandler.Handlers.Clientes
{
    public class ClienteUpdateEventHandler : IRequestHandler<ClienteUpdateCommand, Cliente>
    {
        private readonly ExamenApplicationContext _context;

        public ClienteUpdateEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Handle(ClienteUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _context.Clientes.Where(c => c.Id == request.Id).FirstAsync();

                cliente.Nombre = request.Nombre;
                cliente.Apellidos = request.Apellidos;
                cliente.Direccion = request.Direccion;
                cliente.FechaActualizacion = DateTime.Now;
                
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
