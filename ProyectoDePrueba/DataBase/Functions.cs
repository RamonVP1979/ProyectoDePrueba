using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoDePrueba.DataBase.Contexts;
using ProyectoDePrueba.DataBase.Modelos;
using ProyectoDePrueba.Weatherstack_Api;

namespace ProyectoDePrueba.DataBase
{
    public class Functions
    {




        /// <summary>
        /// Registramos pedido en el entorno de trabajo solicitado
        /// </summary>
        /// <param name="idCliente">Id del Cliente</param>
        /// <param name="idTienda">Id de la tienda</param>
        /// <param name="idPedido">id del pedido</param>
        /// <param name="sandbox">True = "PreProduccion" / False="Produccion" </param>
        public static async Task<RegistroResult> RegistraPedido(string idCliente, string idTienda, string idPedido,string Ciudad, bool sandbox)
        {

            //Creamos el resultado donde vamos englobar todo el proceso.
            RegistroResult Resultado = new RegistroResult();

            try
            {
                
                // Creamos nuevo pedido y rellenamos el tiempo de ciudad.
                Pedido NuevoPedido = ObtenerTemperaturaCiudadPedido(Ciudad, sandbox, ref Resultado);
                // Insertamnos en Base de datos MySQL
                Resultado.MySQLDB_Result = await MySQL.Inserts.Pedidos.InsertarPedido(NuevoPedido, sandbox);
                // Insertamos pedido en base de datos MongoDB
                Resultado.MongoDB_Result = await MongoDB.Inserts.Pedidos.InsertarPedido(NuevoPedido, sandbox);

                // Devolvemos el resultado general de todo el proceso.
                return Resultado;
            }
            catch (Exception ex)
            {
                Resultado.ErrorMessage = ex;
                return Resultado;
            }
            
        
           
        }

        #region ObtenerTemperaturaCiudad

        private static Pedido ObtenerTemperaturaCiudadPedido(string Ciudad,bool sandbox, ref RegistroResult Resultado)
        {
            Pedido NuevoPedido = new Pedido();
            try
            {
                WeatherResult ResultadoTiempo = JsonConvert.DeserializeObject<WeatherResult>(Obtener.Tiempo(Ciudad));
                if (ResultadoTiempo != null)
                {
                    NuevoPedido.temperatura = ResultadoTiempo.current.temperature;
                    NuevoPedido.humedad = ResultadoTiempo.current.humidity;
                    Resultado.Weather_Result = ResultadoTiempo.location.name + " - Ok";
                }
                else
                {
                    Resultado.Weather_Result = Ciudad + " - Ko";
                }

                if (sandbox)
                { Resultado.Entorno = "PreProduccion"; }
                else { Resultado.Entorno = "Produccion"; }

                return NuevoPedido;
            }
            catch (Exception ex)
            {
                Resultado.Weather_Result = ex.Message;
                return NuevoPedido;
            }
        }

        #endregion

    }
}
