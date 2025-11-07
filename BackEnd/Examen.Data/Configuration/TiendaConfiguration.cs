using Examen.Domain.DTiendas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Data.Configuration
{
    public class TiendaConfiguration
    {
        public TiendaConfiguration(EntityTypeBuilder<Tienda> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
