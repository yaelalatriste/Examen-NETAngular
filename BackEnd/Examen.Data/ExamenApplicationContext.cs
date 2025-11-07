using Examen.Data.Configuration;
using Examen.Domain.DArticulos;
using Examen.Domain.DClientes;
using Examen.Domain.DTiendas;
using Microsoft.EntityFrameworkCore;

namespace Examen.Data
{
    public class ExamenApplicationContext : DbContext
    {
        public ExamenApplicationContext(DbContextOptions<ExamenApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelConfig(builder);
        }
        public virtual DbSet<Articulo> Articulos { get; set; }

        public virtual DbSet<ArticuloTienda> ArticuloTienda { get; set; }

        public virtual DbSet<Cliente> Clientes { get; set; }

        public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

        public virtual DbSet<Tienda> Tiendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Adscripcion>().ToTable("c_adsc","dbo");
            //modelBuilder.Entity<Puesto>().ToTable("c_puesto","dbo");
            //modelBuilder.Entity<Ciudad>().ToTable("c_ciudad","dbo");
            //modelBuilder.Entity<Estado>().ToTable("c_estado","dbo");
            //modelBuilder.Entity<Empleado>().ToTable("empleado","dbo");
            //modelBuilder.Entity<Kardex>().ToTable("kdx_nomb","dbo");

            new ArticuloConfiguration(modelBuilder.Entity<Articulo>());
            new ClienteConfiguration(modelBuilder.Entity<Cliente>());
            new TiendaConfiguration(modelBuilder.Entity<Tienda>());
            new ArticuloTiendaConfiguration(modelBuilder.Entity<ArticuloTienda>());
            new ClienteArticulosConfiguration(modelBuilder.Entity<ClienteArticulo>());
        }
    }
}
