using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;
using WeatherApp.Server.Models;
using WeatherApp.Server.Helpers;

namespace WeatherApp.Server.Services
{
    public class OpenWeatherMapService
    {
        private const string ApiKey = "9c996408ef2660b609eb5bf1a3b0150d";
        public static List<WeatherDetail> GetWeatherForecast(string location)
        {
            string url = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={location}&type=accurate&mode=json&units=metric&cnt=5&appid={ApiKey}";
            using (var client = new WebClient())
            {
                try
                {
                    // Synchronous Consumption
                    var response = client.DownloadString(url);
                    var root = JsonConvert.DeserializeObject<OpenWeatherMap.RootObject>(response);
                    return GetWeatherInfo(root);
                }
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
        }

        private static List<WeatherDetail> GetWeatherInfo(OpenWeatherMap.RootObject root)
        {
            var weatherDetails = new List<WeatherDetail>();
            foreach (var list in root.list)
            {
                var weatherDetail = new WeatherDetail();
                var dateTime = DateTimeOffset.FromUnixTimeSeconds(list.dt);

                weatherDetail.date = dateTime.Date.ToString("dd MMM, yyyy");
                weatherDetail.dayOfWeek = dateTime.DayOfWeek.ToString();
                weatherDetail.humidity = $"{list.humidity} %";
                weatherDetail.windSpeed = $"{list.speed} mps";
                if (list.weather != null)
                {
                    weatherDetail.icon = $"http://openweathermap.org/img/w/{list.weather[0].icon}.png";
                    weatherDetail.weather = list.weather[0].main;
                    weatherDetail.description = list.weather[0].description;
                }
                if (list.temp != null)
                {
                    weatherDetail.maxTemp = $"{list.temp.max.Floor()} °C";
                    weatherDetail.minTemp = $"{list.temp.min.Floor()} °C";
                    weatherDetail.temp = $"{list.temp.day.Floor()} °C";
                }

                weatherDetails.Add(weatherDetail);
            }

            return weatherDetails;
        }

    }
}
