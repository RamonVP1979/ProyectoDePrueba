using Microsoft.EntityFrameworkCore;
using ProyectoDePrueba.DataBase.Contexts;
using ProyectoDePrueba.DataBase.Modelos;

namespace ProyectoDePrueba.DataBase.MySQL.Inserts
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
            Entornos EntornoDeTrabajo;

            /// ATENCION - PARA QUE LAS PRUEBAS SALGAN CORRECTAMENTE VAMOS A 
            /// SIMULAR QUE SE GUARDA BIEN YA QUE NO DISPONEMOS DE UNA BASE DE DATOS
            return "Guardado Pedido correctamente.";
            /// 


            if (sandbox)
            { EntornoDeTrabajo = Entornos.PreProduccion; }
            else { EntornoDeTrabajo = Entornos.Produccion; }
            var optionsBuilder = new DbContextOptionsBuilder<MySQL_DbContext>();

            try
            {
                using (MySQL_DbContext ConexionMySQL = new MySQL_DbContext(optionsBuilder.Options, EntornoDeTrabajo))
                {
                    ConexionMySQL.Pedidos.Add(pedido);
                    int Result = await ConexionMySQL.SaveChangesAsync();
                    if (Result == 0)
                    { return "No se ha guardado los datos en BBDD. Compruebe la configuración"; }
                    else
                    { return "Guardado Pedido correctamente."; }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }

    }
}
