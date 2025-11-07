using Examen.Domain.DArticulos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Data.Configuration
{
    public class ArticuloTiendaConfiguration
    {
        public ArticuloTiendaConfiguration(EntityTypeBuilder<ArticuloTienda> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.ArticuloId, x.TiendaId });
        }
    }
}
