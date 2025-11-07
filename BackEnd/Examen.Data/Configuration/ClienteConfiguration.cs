using Examen.Domain.DClientes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Data.Configuration
{
    public class ClienteConfiguration
    {
        public ClienteConfiguration(EntityTypeBuilder<Cliente> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
