using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProyectoDePrueba.DataBase.Modelos;

namespace ProyectoDePrueba.DataBase.Contexts
{

    public enum Entornos { Produccion, PreProduccion }



    public class MySQL_DbContext : DbContext
    {

        public string EntornoConexion = "MySQL_DB_Pre";

        public MySQL_DbContext(DbContextOptions<MySQL_DbContext> options, Entornos EntornoDeTrabajo)
          : base(options)
        {
            if (EntornoDeTrabajo == Entornos.Produccion)
            { EntornoConexion = "MySQL_DB_Pro"; }
            else if (EntornoDeTrabajo == Entornos.PreProduccion)
            { EntornoConexion = "MySQL_DB_Pre"; }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                 .Build();
            var connectionString = configuration.GetConnectionString(EntornoConexion);

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Pedido> Pedidos { get; set; }


    }
}
