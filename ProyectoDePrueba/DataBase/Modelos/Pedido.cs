using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ProyectoDePrueba.DataBase.Modelos
{
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Key]
        public int idCliente { get; set; }
        public int idTienda { get; set; }
        public int idCompra { get; set; }
        public string temperatura { get; set; }
        public string humedad { get; set; }

    }
}
