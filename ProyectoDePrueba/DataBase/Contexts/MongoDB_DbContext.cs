using Microsoft.Extensions.Options;

using MongoDB.Driver;

namespace ProyectoDePrueba.DataBase.Contexts
{
    public interface IMongoBookDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }

   

    public class MongoDB_Configuracion
    {
        public string Conexion { get; } = ObtenerConfiguracion("Conexion");
        public string DatabaseName { get; } = ObtenerConfiguracion("DatabaseName");

        private static string ObtenerConfiguracion(string Parametro)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
             .Build();
            return configuration.GetConnectionString(Parametro);
        }

    }

   
    public class MongoDB_DbContext : IMongoBookDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoDB_DbContext(IOptions<MongoDB_Configuracion> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.Conexion);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
