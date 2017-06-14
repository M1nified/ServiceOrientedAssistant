using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NWeatherService
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IWeatherService
    {
        [OperationContract]
        string SetCity(String city);

        [OperationContract]
        string GetWeatherForecast();
    }
}
