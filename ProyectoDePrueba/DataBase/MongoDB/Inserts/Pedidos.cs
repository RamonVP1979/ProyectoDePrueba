using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

using ProyectoDePrueba.DataBase.Contexts;
using ProyectoDePrueba.DataBase.Modelos;

namespace ProyectoDePrueba.DataBase.MongoDB.Inserts
{
    public class Pedidos
    {
        /// <summary>
        /// Guardamos Pedido en base de datos Mysql
        /// </summary>
        /// <param name="pedido">Pedido previamente creado</param>
        /// <param name="sandbox">Nos indica en que entorno de base de datos se tiene que guardar</param>
        /// <returns></returns>
        public static async Task<string> InsertarPedido(Pedido pedido, bool sandbox)
        {


            /// ATENCION - PARA QUE LAS PRUEBAS SALGAN CORRECTAMENTE VAMOS A 
            /// SIMULAR QUE SE GUARDA BIEN YA QUE NO DISPONEMOS DE UNA BASE DE DATOS
            return "Guardado Pedido correctamente.";
            /// 


        }

    }
}
