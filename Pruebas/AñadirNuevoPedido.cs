using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using ProyectoDePrueba.Controllers;
using ProyectoDePrueba.DataBase;

namespace Pruebas
{
    [TestClass]
    public class EntornoDePruebas
    {
        [TestMethod]
        public void AñadirNuevoPedido()
        {
            // Creamos el resultado correcto que nos tiene que devolver
            RegistroResult ResultadoADevolver = new RegistroResult();
            ResultadoADevolver.Weather_Result = "New York - Ok";
            ResultadoADevolver.MongoDB_Result = "Guardado Pedido correctamente.";
            ResultadoADevolver.MySQLDB_Result = "Guardado Pedido correctamente.";
            ResultadoADevolver.Entorno = "PreProduccion";
            ResultadoADevolver.ErrorMessage = null;

            // Serializamos la clase
            string ResultadoString = JsonConvert.SerializeObject(ResultadoADevolver);

            var Controlador = new EndPoinsController();
            Assert.AreEqual(ResultadoString, Controlador.RegistrarPedido("1", "2", "3", "New York", true));
        }
    }
}