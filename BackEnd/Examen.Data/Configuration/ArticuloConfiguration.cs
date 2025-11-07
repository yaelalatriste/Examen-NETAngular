using Examen.Domain.DArticulos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.Data.Configuration
{
    public class ArticuloConfiguration
    {
        public ArticuloConfiguration(EntityTypeBuilder<Articulo> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
