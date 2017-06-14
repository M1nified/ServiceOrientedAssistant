using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant
{
    class Program
    {
        static void Main(string[] args)
        {
            var weather = new WeatherService.WeatherServiceClient();

            var city = Console.ReadLine();
            weather.SetCity(city);
            var forecast = weather.GetWeatherForecast();

            Console.WriteLine(forecast);

            Console.ReadKey();
        }
    }
}
