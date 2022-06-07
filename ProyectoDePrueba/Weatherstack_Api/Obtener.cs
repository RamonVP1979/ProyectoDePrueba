using Newtonsoft.Json;

using System.Net;
using System.Text;

namespace ProyectoDePrueba.Weatherstack_Api
{
    public class Obtener
    {
        public static string ApiToken = "0dda4fde99d5cbe0fcdff35ec86f761c"; 
        public static string Tiempo(string Ciudad)
        {
            try
            {

                string parametros = "?access_key="+ ApiToken + "&query=" + Ciudad;
                HttpWebRequest Peticion = (HttpWebRequest)WebRequest.Create("http://api.weatherstack.com/current" + parametros);
                Peticion.Method = "GET";
                //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                Peticion.ContentType = "application/x-www-form-urlencoded";
                //Peticion.Expect = "application/json";
              
                Peticion.ContentLength = 0;

                HttpWebResponse response = (HttpWebResponse)Peticion.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string respuestaString = sr.ReadToEnd();

                if (respuestaString.Length > 100)
                {
                    return respuestaString;
                }

                return "";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
