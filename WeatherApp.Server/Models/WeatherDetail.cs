namespace WeatherApp.Server.Models
{
    public class WeatherDetail
    {
        public string weather { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public string date { get; set; }
        public string dayOfWeek { get; set; }
        public string temp { get; set; }
        public string maxTemp { get; set; }
        public string minTemp { get; set; }
        public string windSpeed { get; set; }
        public string humidity { get; set; }
    }
}
