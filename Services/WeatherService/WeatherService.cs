using System;
using System.ServiceModel;

namespace NWeatherService
{
    [ServiceBehavior(Name = "WeatherService",
         Namespace = "http://localhost:8733/Design_Time_Addresses/WeatherService/Service1/",
        InstanceContextMode = InstanceContextMode.PerSession)]
    public class WeatherService : IWeatherService
    {
        private int? _cityId { get; set; } = null;

        public string SetCity(string city)
        {
            Tuple<string, int> res = WeatherAPI.GetCityIdByName(city);
            if(res.Item2 != -1)
            {
                _cityId = res.Item2;
                return "Ustawiono miasto na " + res.Item1;
            }
            return "Nie znaleziono takiego miasta. Spróbuj użyć angielskiej nazwy np. Warsaw";
        }

        public string GetWeatherForecast()
        {
            if(_cityId != null)
            {
                return "TODO";
            }
            return "Aby pobrać prognozę pogody musisz najpierw ustawić miasto";
        }
    }
}
