namespace ProyectoDePrueba.DataBase
{
    public class RegistroResult
    {
       public  string Entorno { get; set; }
        public string MongoDB_Result { get; set; }
        public string MySQLDB_Result { get; set; }
        public string Weather_Result { get; set; }

        public Exception ErrorMessage  { get; set; }
    }
}
