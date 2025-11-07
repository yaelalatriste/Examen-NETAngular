using Examen.Domain.DArticulos;
using Examen.Domain.DClientes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Data.Configuration
{
    public class ClienteArticulosConfiguration
    {
        public ClienteArticulosConfiguration(EntityTypeBuilder<ClienteArticulo> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.ClienteId, x.ArticuloId });
        }
    }
}
