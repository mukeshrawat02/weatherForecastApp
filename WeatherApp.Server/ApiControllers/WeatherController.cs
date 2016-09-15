using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApp.Server.Models;
using WeatherApp.Server.Services;

namespace WeatherApp.Server.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        [Route("api/weather/{location}")]
        public IEnumerable<WeatherDetail> Get(string location)
        {
            return OpenWeatherMapService.GetWeatherForecast(location);
        }
    }
}
