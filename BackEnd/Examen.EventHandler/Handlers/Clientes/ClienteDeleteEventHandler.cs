using Examen.Data;
using Examen.Domain.DClientes;
using Examen.EventHandler.Commands.Clientes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Examen.EventHandler.Handlers.Clientes
{
    public class ClienteDeleteEventHandler : IRequestHandler<ClienteDeleteCommand, Cliente>
    {
        private readonly ExamenApplicationContext _context;

        public ClienteDeleteEventHandler(ExamenApplicationContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Handle(ClienteDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _context.Clientes.Where(c => c.Id == request.Id).FirstAsync();
                cliente.FechaEliminacion = DateTime.Now;
                
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
