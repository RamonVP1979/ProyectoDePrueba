using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ProyectoDePrueba.DataBase;

namespace ProyectoDePrueba.Controllers
{
    [Route("api")]
    [ApiController]
    public class EndPoinsController : ControllerBase
    {


        [HttpGet]
        [Route("get/tiempo")] // Añadir Sesion
        public string ObtenerTiempo([FromHeader] string Ciudad)
        {
            return Weatherstack_Api.Obtener.Tiempo(Ciudad);
        }

        [HttpPost]
        [Route("post/pedido")] // Añadir Sesion
        public string RegistrarPedido([FromHeader] string idCliente, [FromHeader] string idTienda, [FromHeader] string idCompra, string Ciudad, bool sandbox)
        {
            RegistroResult Resultado = Functions.RegistraPedido(idCliente, idTienda, idCompra, Ciudad, sandbox).Result;
            return JsonConvert.SerializeObject(Resultado);
        }

    }
}
