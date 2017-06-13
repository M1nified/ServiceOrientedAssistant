using System;
using System.ServiceModel;

namespace NWeatherService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class WeatherService : IWeatherService
    {
        private int cityId = -1;

        public string SetCity(string city)
        {
            Tuple<string, int> res = WeatherAPI.GetCityIdByName(city);
            if(res.Item2 != -1)
            {
                cityId = res.Item2;
                return "Ustawiono miasto na " + res.Item1;
            }
            return "Nie znaleziono takiego miasta. Spróbuj użyć angielskiej nazwy np. Warsaw";
        }

        public string GetWeatherForecast()
        {
            if(cityId != -1)
            {
                return "TODO";
            }
            return "Aby pobrać prognozę pogody musisz najpierw ustawić miasto";
        }
    }
}
