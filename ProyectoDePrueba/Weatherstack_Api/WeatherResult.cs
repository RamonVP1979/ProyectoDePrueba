namespace ProyectoDePrueba.Weatherstack_Api
{
    public class WeatherResult
    {
        public request request { get; set; }

        public location location { get; set; }

        public current current { get; set; }
    }



    public class request
    {
        public string type { get; set; }
        public string query { get; set; }
        public string language { get; set; }
        public string unit { get; set; }
    }

    public class location
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone_id { get; set; }
        public string localtime { get; set; }
        public string localtime_epoch { get; set; }
        public string utc_offset { get; set; }
    }

    public class current
    {
        public string observation_time { get; set; }
        public string temperature { get; set; }
        public string weather_code { get; set; }
        public string[] weather_icons { get; set; }
        public string[] weather_descriptions { get; set; }
        public string wind_speed { get; set; }
        public string wind_degree { get; set; }
        public string wind_dir { get; set; }
        public string pressure { get; set; }
        public string precip { get; set; }
        public string humidity { get; set; }
        public string cloudcover { get; set; }
        public string feelslike { get; set; }
        public string uv_index { get; set; }
        public string visibility { get; set; }
        public string is_day { get; set; }
    }

}
