using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace NWeatherService
{
    class WeatherAPI
    {
        private static JArray CallRestService(string uri)
        {
            JArray result;

            var req = HttpWebRequest.Create(uri);
            req.Method = "GET";
            req.ContentType = "application/json";

            using (var resp = req.GetResponse())
            {
                var results = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                result = JArray.Parse(results);
            }

            return result;
        }

        public static Tuple<string, int> GetCityIdByName(string cityName)
        {
            JArray res = CallRestService("https://www.metaweather.com/api/location/search/?query=" + cityName);
            if(res.HasValues)
            {
                return Tuple.Create((string)res.First["title"], (int)res.First["woeid"]);
            }
            return Tuple.Create(cityName, -1);
        }
    }
}
